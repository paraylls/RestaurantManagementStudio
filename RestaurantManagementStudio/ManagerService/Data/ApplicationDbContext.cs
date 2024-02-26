using ManagerService.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagerService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<ManagerModel> Manager { get; set; }

    }
}
