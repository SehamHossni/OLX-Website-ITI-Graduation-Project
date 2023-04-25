//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DAL.Entities.Identity;

namespace Talabat.DAL.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    DisplayName = "Ahmed Nasr",
                    UserName = "ahmednasr97",
                    Email = "ahmednasr97@gmail.com",
                    PhoneNumber = "01015317037",
                    Address = new Address()
                    {
                        FirstName = "Ahmed",
                        LastName = "Nasr",
                        Country = "Egypt",
                        City = "Giza",
                        Street = "10 Tahrir St.",
                        ZipCode = "23423"
                    }
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
