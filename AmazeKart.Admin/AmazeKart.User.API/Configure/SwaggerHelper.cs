using AmazeKart.User.API.Filters;
using Microsoft.OpenApi.Models;

namespace AmazeKart.User.API.Configure
{
    public static class SwaggerHelper
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "AmazeKart User APIs", Version = "v1" });
                options.SchemaFilter<SwaggerSchemaExampleFilter>();

                options.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
                {
                    Description = "Authorization header using the Basic scheme (Example: 'Basic 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Basic"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Basic"
                            }
                        },
                        Array.Empty<string>()
                    }
                });                
            });

            return services;
        }
    }
}
