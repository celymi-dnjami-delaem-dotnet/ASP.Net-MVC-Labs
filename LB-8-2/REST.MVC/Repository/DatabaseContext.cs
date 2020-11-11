using Microsoft.EntityFrameworkCore;
using REST.MVC.Models;

namespace REST.MVC.Repository
{
    public class DatabaseContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=master;Persist Security Info=True;User=sa;Password=fakePassw0rd;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasKey(x => x.Id);
            modelBuilder.Entity<UserModel>().Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}