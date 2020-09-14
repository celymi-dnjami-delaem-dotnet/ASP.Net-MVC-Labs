using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using LB_3.Models;
using Newtonsoft.Json;

namespace LB_3.App_Logic
{
    public class ContactsHandler
    {
        private const string FileName = "contacts.json";
        private const string FilePath = @"/App_Data/" + FileName;

        public static IList<PhoneContact> PhoneContacts;

        public static void ReadFromJsonContacts()
        {
            var jsonContacts = File.ReadAllText(HostingEnvironment.MapPath(FilePath));

            PhoneContacts = JsonConvert.DeserializeObject<List<PhoneContact>>(jsonContacts);
        }

        public static List<PhoneContact> WriteToJsonFile(IList<PhoneContact> phoneContacts)
        {
            var jsonPhoneContacts = JsonConvert.SerializeObject(phoneContacts);

            File.WriteAllText(HostingEnvironment.MapPath(FilePath), jsonPhoneContacts);

            PhoneContacts = phoneContacts;

            return PhoneContacts.ToList();
        }
    }
}