namespace LB_3.Models
{
    public class PhoneContact
    {
        public PhoneContact() { }

        public PhoneContact(string id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }
    }
}