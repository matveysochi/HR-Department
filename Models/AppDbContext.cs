using Microsoft.EntityFrameworkCore;
using HRD.Models.SeedData;

namespace HRD.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<EmployeeMovement> EmployeeMovements { get; set; }
        public DbSet<DivisionMovement> DivisionMovements { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Division>()
                .HasMany(d => d.DivisionMovements)
                .WithOne(m => m.Division)
                .HasForeignKey(m => m.DivisionId);
            modelBuilder.Entity<Division>()
                .HasMany(d => d.SubdivisionMovements)
                .WithOne(m => m.ParentDivision)
                .HasForeignKey(m => m.ParentDivisionId);

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new DivisionConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeMovementConfiguration());
            modelBuilder.ApplyConfiguration(new DivisionMovementConfiguration());
        }
    }
}