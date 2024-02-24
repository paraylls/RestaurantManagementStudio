using ManagerService.Models; 
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ManagerService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            SeedData(serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>());
        }

        private static void SeedData(ApplicationDbContext context)
        {
            if (!context.Manager.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Manager.AddRange(
                    new ManagerModel()
                    {
                        FirstName = "Parayll",
                        LastName = "Simnica",
                        BirthDate = DateTime.Now,
                        Gender = "Male",
                        Email = "parayll.simnica@outlook.com",
                        Password = "Password"
                    },
                    new ManagerModel()
                    {
                        FirstName = "Parayll",
                        LastName = "Simnica",
                        BirthDate = DateTime.Now,
                        Gender = "Male",
                        Email = "parayll.simnica@test.com",
                        Password = "Password"
                    }
               );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
