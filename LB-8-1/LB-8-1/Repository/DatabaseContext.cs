using LB_8_1.Models;
using Microsoft.EntityFrameworkCore;

namespace LB_8_1.Repository
{
    public class DatabaseContext : DbContext
    {
        public DbSet<PhoneContact> PhoneContacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:localhost,1434;Initial Catalog=master;Persist Security Info=True;User=sa;Password=fakePassw0rd;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneContact>().HasKey(x => x.Id);
        }
    }
}