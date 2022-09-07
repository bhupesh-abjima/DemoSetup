using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Scrutor;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.HttpOverrides;
using Xamplifier.Services.Infrastructure.Builders.MapperProfile;
using Xamplifier.DataInterfaces;
using Xamplifier.Data;
using Xamplifier.Model;
using Xamplifier.Services;
using Xamplifier.Api.Infrastructure.Filters;
using Xamplifier.Api.Controllers;
using Xamplifier.ServiceInterfaces;

namespace Xamplifier.Api
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            services
                .AddControllers(options =>
                {
                    options.Filters.Add(typeof(HttpGlobalExceptionFilter));
                })
                .AddJsonOptions(x =>
                {
                    x.JsonSerializerOptions.PropertyNamingPolicy = null;
                    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto | ForwardedHeaders.XForwardedHost;
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                                  builder => builder
                                             .SetIsOriginAllowed((host) => true)
                                             .AllowAnyMethod()
                                             .AllowAnyHeader()
                                             .AllowCredentials());
            });
            services.AddHttpContextAccessor();

            return services;
        }
        public static IServiceCollection AddCustomAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DtoToModelMappingProfile));
            services.AddAutoMapper(typeof(ModelToDtoMappingProfile));
            return services;
        }

        public static IServiceCollection AddCustomAutoWrapper(this IServiceCollection services)
        {

            return services;
        }

        public static IServiceCollection AddCustomDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDatabaseFactory>(sp =>
            {
                return new DatabaseFactory(sp.GetRequiredService<ILogger<IDatabaseFactory>>(), configuration.GetConnectionString("DatabaseNameConnString"));
            });
            return services;
        }
        public static IServiceCollection AddCustomAssemblies(this IServiceCollection services)
        {
            var types = new List<Type>() {
                typeof(IDatabaseFactory),
                typeof(DatabaseFactory),
                typeof(INPSPerformanceService),
                typeof(NPSPerformanceService),
                typeof(NPSPerformanceController)
            };

            services.Scan(scan => scan
                .FromAssembliesOf(types)
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsMatchingInterface()
                .WithScopedLifetime());
            services.AddScoped<ApplicationUser>();
            return services;
        }
        public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            services
               .AddHealthChecks()
               .AddCheck(
                   "self",
                   () => HealthCheckResult.Healthy("Xamplifier microservice is live"),
                   new string[] { "live" })
               .AddSqlServer(configuration.GetConnectionString("Default"));

            return services;
        }
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Xamplifier Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' token in the text input below.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = IdentityServerAuthenticationDefaults.AuthenticationScheme
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });
            return services;
        }
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = configuration.GetValue<string>("AuthApi:Host");
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters.ValidAudiences = new List<string>() { configuration.GetValue<string>("AuthApi:ApiName") };
            });

            return services;
        }

    }
}
