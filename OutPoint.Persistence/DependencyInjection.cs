using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OutPoint.Application.Interfaces;
using OutPoint.Domain.Entities;
using OutPoint.Persistence.Context;

namespace OutPoint.Persistence;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OutPointIdentityDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("IdentityConnection"),
                ob => ob.MigrationsAssembly(typeof(OutPointIdentityDbContext).Assembly.FullName)));

        services.AddIdentityCore<ApiUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<OutPointIdentityDbContext>();

        services.AddScoped<IOutPointIdentityDbContext>(p => p.GetService<OutPointIdentityDbContext>());
    }
}