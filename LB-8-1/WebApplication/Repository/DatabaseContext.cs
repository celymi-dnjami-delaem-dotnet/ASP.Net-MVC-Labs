using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Repository
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:localhost,1434;Initial Catalog=master;Persist Security Info=True;User=sa;Password=fakePassw0rd;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(x => x.Id);
        }
    }
}