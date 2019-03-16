using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace DAD_Parking___Back.Data
{
    public class SeedDatabase
    {        
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<DADParkingDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<DADParkingUser>>();            
            context.Database.EnsureCreated();

            if(!context.Users.Any())
            {
                DADParkingUser user = new DADParkingUser
                {
                    Email = "teste@teste.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "Teste"
                };

                userManager.CreateAsync(user, "Test3@User");
            }
        }
    }
}