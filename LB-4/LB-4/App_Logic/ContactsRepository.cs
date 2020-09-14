using LB_4.Models.DB;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace LB_4.App_Logic
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly ContactsContext _contactsContext;

        public ContactsRepository()
        {
            _contactsContext = new ContactsContext();
        }

        public async Task AddContact(PhoneContactModel phoneContact)
        {
            _contactsContext.PhoneContacts.Add(phoneContact);

            await _contactsContext.SaveChangesAsync();
        }

        public async Task DeleteContact(PhoneContactModel phoneContact)
        {
            var contact = await _contactsContext.PhoneContacts.FirstOrDefaultAsync(c => c.Id == phoneContact.Id);

            if (contact != null)
            {
                _contactsContext.PhoneContacts.Remove(contact);

                await _contactsContext.SaveChangesAsync();
            }
        }

        public async Task<List<PhoneContactModel>> GetPhoneContacts()
        {
            return await _contactsContext.PhoneContacts.AsNoTracking().ToListAsync();
        }

        public async Task UpdateContact(PhoneContactModel phoneContact)
        {
            _contactsContext.Entry(phoneContact).State = EntityState.Modified;

            await _contactsContext.SaveChangesAsync();
        }
    }
}