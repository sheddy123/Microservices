using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PlatformService.Data;
using PlatformService.Models;
using PlatformService.Models.Mappings;

namespace PlatformService.Extensions.Program;

public static partial class ServiceInitializer
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        RegisterHttpClientDependencies(services);
        RegisterCustomDependencies(services);
        services.AddAutoMapper(typeof(RegisterMappings));
        RegisterSwagger(services);
        RegisterCors(services, configuration);

        return services;
    }

    private static void RegisterCustomDependencies(IServiceCollection services)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile(Constants.Default.AppSettingJson)
            .AddEnvironmentVariables()
            .Build();

        var appSettingsSection = config.GetSection(Constants.Default.AppSettings);
        services.Configure<AppSettings>(appSettingsSection);

        //configure jwt authentication
        // var appSettings = appSettingsSection.Get<AppSettings>();
        // var key = Encoding.ASCII.GetBytes(appSettings?.Secret);

        //configure database context
        services.AddDbContext<AppDbContext>(opt => 
            opt.UseInMemoryDatabase("InMem"));

        // Add authentication services with your custom handler
        // services.AddAuthentication(Constants.Default.CustomAuthorization)
        //     .AddScheme<AuthenticationSchemeOptions, CustomJwtAuthenticationHandler>(
        //         Constants.Default.CustomAuthorization, options => { });

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddSingleton<IConfiguration>(config);
        services.AddScoped<IPlatformRepo, PlatformRepo>();
        //services.AddSingleton<IProfileRepo, ProfileRepo>();
    }

    private static void RegisterHttpClientDependencies(IServiceCollection services)
    {
        services.AddHttpClient("PlatformService");
    }

    private static void RegisterSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            //options.SwaggerDoc("v1", new OpenApiInfo
            //{
            //    Version = "v1",
            //    Title = "ToDo API",
            //    Description = "An ASP.NET Core Web API for managing ToDo items",
            //    TermsOfService = new Uri("https://example.com/terms"),
            //    Contact = new OpenApiContact
            //    {
            //        Name = "Example Contact",
            //        Url = new Uri("https://example.com/contact")
            //    },
            //    License = new OpenApiLicense
            //    {
            //        Name = "Example License",
            //        Url = new Uri("https://example.com/license")
            //    }

            //});
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hybrid GPT-3 Auth Scheme", Version = "v1" });
            c.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme()
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Basic",
                Description = "Input your username and password to access this API",
            });
            c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme()
            {
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                Description = "Input bearer token to access this API",
            });
            c.AddSecurityDefinition("apiKeyAuth", new OpenApiSecurityScheme()
            {
                Type = SecuritySchemeType.ApiKey,
                Name = "key",
                Scheme = "apikey",
                Description = "Input apikey to access this API",
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "apiKeyAuth" }
                    },
                    new[] { "Hybrid GPT-3 Auth Scheme" }
                },
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth" }
                    },
                    new[] { "Hybrid GPT-3 Auth Scheme" }
                },
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
                    },
                    new[] { "Hybrid GPT-3 Auth Scheme" }
                }
            });
           
            // // using System.Reflection;
            // var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            // c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
    }

    private static void RegisterCors(IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: Constants.Default.MyAllowSpecificOrigins,
                builder =>
                {
                    //get appsettings config here
                    // Retrieve appsettings value
                    // var allowedOrigins = configuration.GetSection(Constants.Default.AppSettings);
                    // var corsSettings = allowedOrigins.GetSection("Policies").Get<string>();
                    // string[] corsSettingsObj = corsSettings.Split(",");
                    //var allowedOrigins = configuration.GetSection("CorsSettings:AllowedOrigins").Get<string[]>();

                    // builder.WithOrigins(corsSettingsObj).AllowAnyHeader()
                    //     .AllowAnyMethod().AllowCredentials();
                    //.SetIsOriginAllowedToAllowWildcardSubdomains()
                    //.WithExposedHeaders("Set-Cookie"); 
                });
        });
    }
}