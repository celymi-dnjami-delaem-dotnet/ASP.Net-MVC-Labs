using System.Collections.Generic;
using System.Threading.Tasks;
using JSON.DAL.Models;

namespace JSON.DAL.Json
{
    public interface IPhoneDictionary
    {
        IEnumerable<PhoneContact> GetContacts();
        void AddContact(PhoneContact phoneContact);
        void UpdateContact(PhoneContact phoneContact);
        void RemoveContact(PhoneContact phoneContact);
    }
}
