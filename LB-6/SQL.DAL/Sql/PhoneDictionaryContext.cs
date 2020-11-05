using System.Data.Entity;
using SQL.DAL.Models;

namespace SQL.DAL.Sql
{
    public class PhoneDictionaryContext : DbContext
    {
        public DbSet<PhoneContact> PhoneContacts { get; set; }

        public PhoneDictionaryContext() : base("ContactsContext") { }
    }
}
