using System.Threading.Tasks;
using System.Web.Mvc;
using SQL.DAL.Sql;
using SQL.DAL.Models;

namespace LB_6.Controllers
{
    public class SqlContactsController : Controller
    {
        private readonly IPhoneDictionary _sqlPhoneDictionary;

        public SqlContactsController(IPhoneDictionary sqlPhoneDictionary)
        {
            _sqlPhoneDictionary = sqlPhoneDictionary;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await _sqlPhoneDictionary.GetContacts());
        }

        [HttpGet]
        public ActionResult Add(PhoneContact phoneContact)
        {
            return View(phoneContact);
        }

        [HttpPost]
        public async Task<ActionResult> AddSave(PhoneContact phoneContact)
        {
            await _sqlPhoneDictionary.AddContact(phoneContact);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(PhoneContact phoneContact)
        {
            return View(phoneContact);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateSave(PhoneContact phoneContact)
        {
            await _sqlPhoneDictionary.UpdateContact(phoneContact);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Remove(PhoneContact phoneContact)
        {
            return View(phoneContact);
        }

        [HttpPost]
        public async Task<ActionResult> RemoveSave(PhoneContact phoneContact)
        {
            await _sqlPhoneDictionary.RemoveContact(phoneContact);

            return RedirectToAction("Index");
        }
    }
}