﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Teams.Domain.Repositories;
using Teams.Infrastructure.DAL;
using Teams.Infrastructure.DAL.Repositories;
using Teams.Infrastructure.Exceptions;

namespace Teams.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddSingleton<ExceptionMiddleware>();
        services.AddDbContext(configuration);
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
