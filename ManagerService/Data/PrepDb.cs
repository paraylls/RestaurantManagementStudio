namespace ManagerService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serivesScope = app.ApplicationServices.CreateScope())
            {
                IServiceProvider serviceProvider = serivesScope.ServiceProvider;
                SeedData(context: serviceProvider.GetService<ApplicationDbContext>());
            }
        }

        private static void SeedData(ApplicationDbContext context)
        {
            if (!context.Manager.Any())
            {
                Console.WriteLine("--> Seeding Data...");
            }else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
