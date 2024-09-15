using AutoMapper;
using CabeleleilaLeila.Application.ApiManagement;
using CabeleleilaLeila.Application.Helpers;
using CabeleleilaLeila.Application.Interfaces;
using CabeleleilaLeila.Application.Mapping;
using CabeleleilaLeila.Application.Services;
using CabeleleilaLeila.Domain.Interfaces;
using CabeleleilaLeila.Infraestructure;
using CabeleleilaLeila.Infraestructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Threading.RateLimiting;

namespace CabeleleilaLeila.CrossCutting.Ioc;

public static class ConfigureServicesExtension
{
    private static IServiceCollection ServiceCollection { get; set; } = new ServiceCollection();
    private static IConfiguration? Configuration { get; set; }

    public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        ServiceCollection = serviceCollection;
        Configuration = configuration;

        AddControlers();
        AddOptions();
        AddTransient();
        AddSingleton();
        AddSwaggerGen();
        AddMySql();
        AddCors();
        AddRateLimit();
        SetApiData();

        return ServiceCollection;
    }

    private static void AddControlers()
    {
        ServiceCollection.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            options.SerializerSettings.Formatting = Formatting.Indented;
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });
    }

    private static void AddOptions()
    {
        ServiceCollection.AddOptions();
    }

    private static void AddTransient()
    {
        ServiceCollection.AddTransient<IUserService, UserService>();
        ServiceCollection.AddTransient<ISchedulingService, SchedulingService>();

        ServiceCollection.AddTransient<IUserRepository, UserRepository>();
        ServiceCollection.AddTransient<ISchedulingRepository, SchedulingRepository>();

        ServiceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
        ServiceCollection.AddTransient<IEmail, Email>();
        ServiceCollection.AddTransient<IApiDataService, ApiDataService>();
    }

    private static void AddSingleton()
    {
        var configure = new MapperConfiguration(config => { config.AddProfile(new MapperGeneric<string, string>()); });
        IMapper mapper = configure.CreateMapper();
        ServiceCollection.AddSingleton(mapper);
        ServiceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }

    private static void AddSwaggerGen()
    {
        OpenApiContact contact = new()
        {
            Name = "Cabeleleila Leila",
            Url = new Uri("https://github.com/danibassetto")
        };

        ServiceCollection.AddSwaggerGen(x =>
        {
            x.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Cabeleleila Leila",
                Description = "Sistema de agendamento de serviços no Salão da Leila",
                Version = "v1",
                Contact = contact
            });
        });

        ServiceCollection.AddSwaggerGenNewtonsoftSupport();
    }

    private static void AddMySql()
    {
        var connectionString = Configuration!.GetConnectionString("DataBase");

        ServiceCollection.AddDbContext<CabeleleilaLeilaContext>(opts => opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }

    private static void AddCors()
    {
        ServiceCollection.AddCors(options => options.AddPolicy("wasm", policy => policy.WithOrigins("https://localhost:5082", "http://localhost:5083").AllowAnyMethod().SetIsOriginAllowed(pol => true).AllowAnyHeader().AllowCredentials()));
    }

    private static void AddRateLimit()
    {
        ServiceCollection.AddRateLimiter(options =>
        {
            options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

            options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpcontext =>
                                    RateLimitPartition.GetFixedWindowLimiter(partitionKey: httpcontext.Request.Headers.Host.ToString(),
                                    factory: partition => new FixedWindowRateLimiterOptions
                                    {
                                        AutoReplenishment = true,
                                        PermitLimit = 2,
                                        QueueLimit = 0,
                                        Window = TimeSpan.FromSeconds(5)
                                    }));
        });
    }

    private static void SetApiData()
    {
        ApiData.SetMapper(new Application.Mapping.Mapper(new MapperConfiguration(config => { config.AddProfile(new MapperEntityOutput()); }).CreateMapper(), new MapperConfiguration(config => { config.AddProfile(new MapperInputEntity()); }).CreateMapper()));
    }
}