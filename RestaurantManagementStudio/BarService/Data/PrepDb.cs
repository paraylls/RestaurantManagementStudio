using BarService.Models;

namespace BarService.Data
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
            if (!context.Bartenders.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Bartenders.AddRange(
                    new BartenderModel()
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        DateOfBirth = DateTime.Now,
                        Gender = "Male",
                        Email = "john.doe@example.com",
                        Password = "Password"
                    },
                    new BartenderModel()
                    {
                        FirstName = "Jane",
                        LastName = "Smith",
                        DateOfBirth = DateTime.Now,
                        Gender = "Female",
                        Email = "jane.smith@example.com",
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
