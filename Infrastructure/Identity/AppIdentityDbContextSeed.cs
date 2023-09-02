using System.Threading.Tasks;
using Core.Enities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            var user = new AppUser
            {
                DisplayName = "Mahmoud",
                Email = "Mahmoud@shop.com",
                UserName = "Mahmoud@shop.com",
                Address = new Address
                {
                    FirstName = "Mahmoud",
                    LastName = "Ahmed",
                    Street = "10th",
                    City = "Abu Hammad",
                    Government = "Ash Sharqia",
                    Country = "Egypt",
                    ZipCode = "44661"
                }
            };

            await userManager.CreateAsync(user, "M.a28101997");
        }

    }
}