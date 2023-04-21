using AmazeKart.Admin.Core.IRepositories;
using AmazeKart.Admin.Core.ObjectModel;
using AmazeKart.Admin.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using NetCore.AutoRegisterDi;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var coreAssembly = Assembly.Load("AmazeKart.Admin.Core");
var infrastructureAssembly = Assembly.Load("AmazeKart.Admin.Infrastructure");
var sqlToScan = Assembly.GetAssembly(typeof(IUnitOfWork));

builder.Services.AddDbContext<AmazeKartDB>(options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration?.GetConnectionString("AmazeKartDB")?.ToString(), options => options.EnableRetryOnFailure()));

Assembly[] assemblies = { coreAssembly, infrastructureAssembly };
builder.Services.RegisterAssemblyPublicNonGenericClasses(assemblies)
    .Where(c => c.Namespace.StartsWith("AmazeKart") && !(c.Name.ToLower().EndsWith("unitofwork")))
    .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();