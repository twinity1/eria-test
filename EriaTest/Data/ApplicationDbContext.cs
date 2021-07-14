using EriaTest.Data.Entities;
using EriaTest.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace EriaTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Assigment> Assigments { get; set; }
        
        public DbSet<AssigmentType> AssigmentTypes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssigmentType>().HasData(new AssigmentTypeSeed().Seed());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}