using System.Web.Mvc;
using JSON.DAL.Json;
using JSON.DAL.Models;

namespace LB_6.Controllers
{
    public class JsonContactsController : Controller
    {
        private readonly IPhoneDictionary _jsonPhoneDictionary;

        public JsonContactsController(IPhoneDictionary jsonPhoneDictionary)
        {
            _jsonPhoneDictionary = jsonPhoneDictionary;
        }

        public ActionResult Index()
        {
            return View(_jsonPhoneDictionary.GetContacts());
        }

        [HttpGet]
        public ActionResult Add(PhoneContact phoneContact)
        {
            return View(phoneContact);
        }

        [HttpPost]
        public ActionResult AddSave(PhoneContact phoneContact)
        {
            _jsonPhoneDictionary.AddContact(phoneContact);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(PhoneContact phoneContact)
        {
            return View(phoneContact);
        }

        [HttpPost]
        public ActionResult UpdateSave(PhoneContact phoneContact)
        {
            _jsonPhoneDictionary.UpdateContact(phoneContact);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Remove(PhoneContact phoneContact)
        {
            return View(phoneContact);
        }

        [HttpPost]
        public ActionResult RemoveSave(PhoneContact phoneContact)
        {
            _jsonPhoneDictionary.RemoveContact(phoneContact);

            return RedirectToAction("Index");
        }
    }
}