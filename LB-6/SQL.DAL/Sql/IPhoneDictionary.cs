using System.Collections.Generic;
using System.Threading.Tasks;
using SQL.DAL.Models;

namespace SQL.DAL.Sql
{
    public interface IPhoneDictionary
    {
        Task<IEnumerable<PhoneContact>> GetContacts();
        Task AddContact(PhoneContact phoneContact);
        Task UpdateContact(PhoneContact phoneContact);
        Task RemoveContact(PhoneContact phoneContact);
    }
}
