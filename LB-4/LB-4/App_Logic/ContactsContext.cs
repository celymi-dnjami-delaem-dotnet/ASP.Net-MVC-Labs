using System.Data.Entity;
using LB_4.Models.DB;

namespace LB_4.App_Logic
{
    public class ContactsContext : DbContext
    {
        public DbSet<PhoneContactModel> PhoneContacts { get; set; }

        public ContactsContext() : base("ContactsContext") { }
    }
}