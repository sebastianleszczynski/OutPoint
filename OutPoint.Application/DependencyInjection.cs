using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OutPoint.Domain.Entities;

namespace OutPoint.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.Configure<IdentityOptions>(options =>
        {
            options.User.AllowedUserNameCharacters = null;
        });
    }
}