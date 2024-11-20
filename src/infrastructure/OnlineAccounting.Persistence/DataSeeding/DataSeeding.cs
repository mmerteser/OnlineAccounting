using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineAccounting.Domain.Entities.AppEntities.Identity;
using OnlineAccounting.Persistence.Context;

namespace OnlineAccounting.Persistence.DataSeeding;

public static class DataSeeding
{
    public static IServiceProvider CreateMigration(this IServiceProvider services)
    {
        var context = services.GetRequiredService<AppDbContext>();
        if (!context.Database.EnsureCreated())
            context.Database.Migrate();

        return services;
    }

    public static IServiceProvider AddAdminUser(this IServiceProvider services)
    {
        var context = services.GetRequiredService<AppDbContext>();

        var user = CreateUser();

        var _userManager = services.GetRequiredService<UserManager<AppUser>>();
        var _userStore = services.GetRequiredService<IUserStore<AppUser>>();

        if (context.Users.Any())
            return services;

        var email = "admin@admin.com";
        var username = email;
        var password = "123Qwe";

        _userStore.SetUserNameAsync(user, username, CancellationToken.None).GetAwaiter().GetResult();
        ((IUserEmailStore<AppUser>)_userStore).SetEmailAsync(user, email, CancellationToken.None).GetAwaiter()
            .GetResult();
        _userManager.CreateAsync(user, password).GetAwaiter().GetResult();

        return services;
    }

    private static AppUser CreateUser()
    {
        try
        {
            return Activator.CreateInstance<AppUser>();
        }
        catch
        {
            throw new InvalidOperationException($"Can't create an instance of '{nameof(AppUser)}'. ");
        }
    }
}