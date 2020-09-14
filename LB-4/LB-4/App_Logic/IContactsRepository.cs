using System.Collections.Generic;
using System.Threading.Tasks;
using LB_4.Models.DB;

namespace LB_4.App_Logic
{
    public interface IContactsRepository
    {
        Task<List<PhoneContactModel>> GetPhoneContacts();
        Task AddContact(PhoneContactModel phoneContact);
        Task UpdateContact(PhoneContactModel phoneContact);
        Task DeleteContact(PhoneContactModel phoneContact);
    }
}
