using System.Threading.Tasks;
using System.Web.Mvc;
using LB_4.App_Logic;
using LB_4.Models.DB;

namespace LB_4.Controllers
{
    public class DictController : Controller
    {
        private readonly IContactsRepository _contactsRepository;

        public DictController()
        {
            _contactsRepository = new ContactsRepository();
        }

        public async Task<ActionResult> Index()
        {
            var contacts = await _contactsRepository.GetPhoneContacts();

            return View(contacts);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddSave(PhoneContactModel phoneContact)
        {
            await _contactsRepository.AddContact(phoneContact);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(PhoneContactModel phoneContact)
        {
            return View(phoneContact);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateSave(PhoneContactModel phoneContact)
        {
            await _contactsRepository.UpdateContact(phoneContact);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Remove(PhoneContactModel phoneContact)
        {
            return View(phoneContact);
        }

        [HttpPost]
        public async Task<ActionResult> RemoveSave(PhoneContactModel phoneContact)
        {
            await _contactsRepository.DeleteContact(phoneContact);

            return RedirectToAction("Index");
        }
    }
}