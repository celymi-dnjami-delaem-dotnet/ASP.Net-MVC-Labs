using System.Collections.Generic;
using System.Threading.Tasks;
using LB_8_1.Models;
using Microsoft.EntityFrameworkCore;

namespace LB_8_1.Repository
{
    public class PhoneContactsRepository : IPhoneContactsRepository
    {
        private readonly DatabaseContext _databaseContext;

        public PhoneContactsRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        
        public async Task<List<PhoneContact>> GetPhoneContacts()
        {
            return await _databaseContext.PhoneContacts.AsNoTracking().ToListAsync();
        }

        public async Task AddPhoneContact(PhoneContact phoneContact)
        {
            await _databaseContext.PhoneContacts.AddAsync(phoneContact);

            await _databaseContext.SaveChangesAsync();
        }

        public async Task UpdatePhoneContact(PhoneContact phoneContact)
        {
            _databaseContext.Update(phoneContact);
            
            await _databaseContext.SaveChangesAsync();
        }

        public async Task RemovePhoneContact(int id)
        {
            var deletingEntity = await _databaseContext.PhoneContacts
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
            if (deletingEntity != null)
            {
                _databaseContext.Remove(deletingEntity);
            }

            await _databaseContext.SaveChangesAsync();
        }
    }
}