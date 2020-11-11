using System.Collections.Generic;
using System.Threading.Tasks;
using LB_8_1.Models;

namespace LB_8_1.Repository
{
    public interface IPhoneContactsRepository
    {
        Task<List<PhoneContact>> GetPhoneContacts();

        Task AddPhoneContact(PhoneContact phoneContact);

        Task UpdatePhoneContact(PhoneContact phoneContact);
        
        Task RemovePhoneContact(int id);
    }
}