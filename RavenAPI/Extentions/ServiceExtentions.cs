using Microsoft.EntityFrameworkCore;
using Entities;
using Repo.Contracts;
using Repo;
using Services;
using Services.Contracts;
using Npgsql;
using Contracts;
using LoggerService;

namespace RavenAPI.Extentions;

public static class ServiceExtentions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
    }
    public static void ConfigureIISIntegration(this IServiceCollection services)
    {
        services.Configure<IISOptions>(options => { });
    }
    public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();
    public static void ConfigurePostgresContext(this IServiceCollection services, IConfiguration config)
    {
        var conStr = new NpgsqlConnectionStringBuilder(
            config.GetConnectionString("pgConnection"))
        {
            Username = config["POSTGRES_USER"],
            Password = config["POSTGRES_PASSWORD"]
        };
        var connectionString = conStr.ConnectionString;
        services.AddDbContext<ravenContext>(o => o.UseNpgsql(connectionString));
    }
    public static void ConfigureManager(this IServiceCollection services)
    {
        services.AddScoped<IRepoManager, RepoManager>();
        services.AddScoped<IServiceManager, ServiceManager>();
    }
}