using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Teams.Application.Common.Abstracts;
using Teams.Domain.Repositories;
using Teams.Infrastructure.Clients;
using Teams.Infrastructure.DAL;
using Teams.Infrastructure.DAL.Repositories;
using Teams.Infrastructure.Exceptions;

namespace Teams.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddSingleton<ExceptionMiddleware>();
        services.AddDbContext(configuration);
        services.AddHttpClient<IRandomMemberClient, RandomMemberClient>();
        return services;
    }

    public static IApplicationBuilder UseInfrasctructure(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        return app;
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TeamDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly(typeof(TeamDbContext).Assembly.FullName)));
        
        services.AddHostedService<DatabaseInitializer>();
        return services;
    }
}
