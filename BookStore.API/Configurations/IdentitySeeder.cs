
using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace BookStore.API.Configurations
{
    
    //هنا استاتك ع انا مش هستخدم الكلاس دى ف اى حته تانى انا عايزه هيلبر بس 
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            //GetRequiredService لو ف حاجه غلط هيرمى اكسيبشن 
            //GetService لو ف حاجه غلط هيرمى نال وساعتها البرنامج مش هيقف ومش هرف فين المشكله  
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var superAdminSettings = serviceProvider.GetRequiredService<IOptions<SuperAdminSettings>>();
           var superAdminSetting= superAdminSettings.Value;
            var roles = new List<string>
            {
                "Admin",
                "Doctor",
                "Patient",
                "Receptionist"
            };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            var admin =await userManager.FindByEmailAsync(superAdminSetting.Email);
            if (admin==null)
            {
                var user = new ApplicationUser()
                {
                    UserName = superAdminSetting.Username,
                    Email= superAdminSetting.Email,
                    PhoneNumber= superAdminSetting.PhoneNumber,
                    EmailConfirmed=true,
                };
               var createUser= await userManager.CreateAsync(user, superAdminSetting.Password);
                if (!createUser.Succeeded)
                {
                    var errors = string.Join(", ", createUser.Errors.Select(e => e.Description));
                    throw new Exception($"Failed to create Super Admin: {errors}");
                }
                var createRole=await userManager.AddToRoleAsync(user, "Admin");
                if (!createRole.Succeeded)
                {
                    var errors = string.Join(", ", createRole.Errors.Select(e => e.Description));
                    throw new Exception($"Failed to add role Admin: {errors}");
                }

            }

        }
    }

}
