using KargoTakip.Backend.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace KargoTakip.Backend.WebAPI;

public static class ExtensionsMiddleware
{
    public static void CreateFirstUser(WebApplication app)
    {
        using (var scoped = app.Services.CreateScope())
        {
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            if (!userManager.Users.Any(p => p.UserName == "admin"))
            {
                AppUser user = new()
                {
                    Id = Guid.Parse("12e7a4b5-43bf-402c-b57e-2fd106ec0689"),
                    UserName = "admin",
                    Email = "admin@admin.com",
                    FirstName = "Emre",
                    LastName = "Can",
                    EmailConfirmed = true,
                    CreateAt = DateTimeOffset.Now,
                };

                user.CreateUserId = user.Id;

                userManager.CreateAsync(user, "1").Wait();


            }
        }
    }
}
