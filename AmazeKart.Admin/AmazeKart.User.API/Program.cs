using AmazeKart.User.API.App_Start;
using AmazeKart.User.API.Configure;
using AmazeKart.User.Core.IRepositories;
using AmazeKart.User.Core.ObjectModel;
using AmazeKart.User.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using NetCore.AutoRegisterDi;
using Newtonsoft.Json.Serialization;
using System.Reflection;

Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureSwagger();

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
})
.AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
});

builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

var coreAssembly = Assembly.Load("AmazeKart.User.Core");
var infrastructureAssembly = Assembly.Load("AmazeKart.User.Infrastructure");

var sqlToScan = Assembly.GetAssembly(typeof(IUnitOfWork));

Assembly[] assemblies = { coreAssembly, infrastructureAssembly };
builder.Services.RegisterAssemblyPublicNonGenericClasses(assemblies)
    .Where(c => c.Namespace.StartsWith("AmazeKart") && !(c.Name.ToLower().EndsWith("unitofwork")))
    .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

string connectionString = builder.Configuration?.GetConnectionString("AmazeKartDB")?.ToString();
builder.Services.AddDbContext<AmazeKartDB>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString, options => options.EnableRetryOnFailure()));
builder.Services.AddAutoMapper(c => c.AddProfile<AutomapperConfiguration>(), typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
    app.UseDeveloperExceptionPage();
}

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();