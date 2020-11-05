using JSON.DAL.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;

namespace JSON.DAL.Json
{
    public class PhoneDictionary : IPhoneDictionary
    {
        private const string FileName = "Contacts.json";
        private const string FilePath = @"/App_Data/" + FileName;

        private static List<PhoneContact> _phoneContacts;

        public void AddContact(PhoneContact phoneContact)
        {
            var maxId = _phoneContacts.Count != 0 ? _phoneContacts.Max(x => x.Id) : 0;
            phoneContact.Id = maxId + 1;

            _phoneContacts.Add(phoneContact);

            WriteToFile();
        }

        public IEnumerable<PhoneContact> GetContacts()
        {
            var file = File.ReadAllText(HostingEnvironment.MapPath(FilePath));
            _phoneContacts = JsonConvert.DeserializeObject<List<PhoneContact>>(file);

            return _phoneContacts;
        }

        public void RemoveContact(PhoneContact phoneContact)
        {
            _phoneContacts.RemoveAll(c => c.Id == phoneContact.Id);

            WriteToFile();
        }

        public void UpdateContact(PhoneContact phoneContact)
        {
            var contact = _phoneContacts.FirstOrDefault(c => c.Id == phoneContact.Id);
            if (contact != null)
            {
                contact.Name = phoneContact.Name;
                contact.Phone = phoneContact.Phone;
            }

            WriteToFile();
        }

        private void WriteToFile()
        {
            var serializedContacts = JsonConvert.SerializeObject(_phoneContacts);
            File.WriteAllText(HostingEnvironment.MapPath(FilePath), serializedContacts);
        }
    }
}
