using Microsoft.EntityFrameworkCore;
using DamInspectionApi.Models;

namespace DamInspectionApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Dam> Dams { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
    }
}
