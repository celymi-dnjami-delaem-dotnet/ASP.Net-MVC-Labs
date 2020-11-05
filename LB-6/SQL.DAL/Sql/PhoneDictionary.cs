using SQL.DAL.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace SQL.DAL.Sql
{
    public class PhoneDictionary : IPhoneDictionary
    {
        private readonly PhoneDictionaryContext _phoneDictionaryContext;

        public PhoneDictionary(PhoneDictionaryContext phoneDictionaryContext)
        {
            _phoneDictionaryContext = phoneDictionaryContext;
        }

        public async Task AddContact(PhoneContact phoneContact)
        {
            _phoneDictionaryContext.PhoneContacts.Add(phoneContact);

            await _phoneDictionaryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PhoneContact>> GetContacts()
        {
            return await _phoneDictionaryContext.PhoneContacts.AsNoTracking().ToListAsync();
        }

        public async Task RemoveContact(PhoneContact phoneContact)
        {
            var contact = await _phoneDictionaryContext.PhoneContacts.FirstOrDefaultAsync(c => c.Id == phoneContact.Id);
            if (contact != null)
            {
                _phoneDictionaryContext.PhoneContacts.Remove(contact);
            }

            await _phoneDictionaryContext.SaveChangesAsync();
        }

        public async Task UpdateContact(PhoneContact phoneContact)
        {
            _phoneDictionaryContext.PhoneContacts.AddOrUpdate(phoneContact);

            await _phoneDictionaryContext.SaveChangesAsync();
        }
    }
}
