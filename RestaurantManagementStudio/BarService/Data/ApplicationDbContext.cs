using BarService.Models;
using Microsoft.EntityFrameworkCore;

namespace BarService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<BartenderModel> Bartenders { get; set; }
    }
}
