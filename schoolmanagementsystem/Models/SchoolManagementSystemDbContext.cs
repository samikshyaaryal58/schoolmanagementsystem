using Microsoft.EntityFrameworkCore;
using System.IO.Pipelines;

namespace schoolmanagementsystem.Models
{
    public class SchoolManagementSystemDbContext:DbContext
    {
        public SchoolManagementSystemDbContext(DbContextOptions<SchoolManagementSystemDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Classes> Classes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string)))
            {
                property.SetColumnType("text");  // or "varchar"
            }

            // Other model configurations...
        }
    }
}
