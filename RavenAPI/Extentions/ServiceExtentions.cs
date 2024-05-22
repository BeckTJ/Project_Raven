using Microsoft.EntityFrameworkCore;
using Entities;
using Repo.Contracts;
using Repo;
using Services;
using Services.Contracts;
using Npgsql;

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
    public static void ConfigurePostgresContext(this IServiceCollection services, IConfiguration config)
    {
        var conStr = new NpgsqlConnectionStringBuilder(
            config.GetConnectionString("pgConnection"))
        {
            Username = config["POSTGRES_USER"],
            Password = config["POSTGRES_PASSWORD"]
        };
        var connectionString = conStr.ConnectionString;
        services.AddDbContext<ravenContext>(o => o.UseNpgsql(connectionString!));
    }
    public static void ConfigureRepoManager(this IServiceCollection services)
    {
        services.AddScoped<IRepoManager, RepoManager>();
    }
    public static void ConfigureServiceManager(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
    }
}