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
        var _roleManager = services.GetRequiredService<RoleManager<AppRole>>();

        if (context.Users.Any())
            return services;

        string email = "admin@admin.com";
        string username = email;
        string password = "123Qwe";
        string fullName = "Admin";

        user.FullName = fullName;

        _userStore.SetUserNameAsync(user, username, CancellationToken.None).GetAwaiter().GetResult();
        ((IUserEmailStore<AppUser>)_userStore).SetEmailAsync(user, email, CancellationToken.None).GetAwaiter()
            .GetResult();
        _userManager.CreateAsync(user, password).GetAwaiter().GetResult();
        
        if(!_roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult())
            _roleManager.CreateAsync(new AppRole(){Name = "Admin"}).GetAwaiter().GetResult();
            
        _userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();
        
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