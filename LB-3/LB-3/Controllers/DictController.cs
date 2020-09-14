using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LB_3.App_Logic;
using LB_3.Models;

namespace LB_3.Controllers
{
    public class DictController : Controller
    {
        private List<PhoneContact> _phoneContacts;

        public DictController()
        {
            _phoneContacts = ContactsHandler.PhoneContacts.ToList();
        }

        public ActionResult Index()
        {
            return View(_phoneContacts.OrderBy(c => c.Name).ToList());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSave(PhoneContact phoneContact)
        {
            _phoneContacts.Add(phoneContact);
            _phoneContacts = ContactsHandler.WriteToJsonFile(_phoneContacts);

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
            _phoneContacts = _phoneContacts.Select(c => c.Id == phoneContact.Id ? new PhoneContact(phoneContact.Id, phoneContact.Name, phoneContact.Phone) : c).ToList();
            _phoneContacts = ContactsHandler.WriteToJsonFile(_phoneContacts);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(PhoneContact phoneContact)
        {
            return View(phoneContact);
        }

        [HttpPost]
        public ActionResult DeleteSave(PhoneContact phoneContact)
        {
            _phoneContacts.RemoveAll(c => c.Id == phoneContact.Id);
            _phoneContacts = ContactsHandler.WriteToJsonFile(_phoneContacts);

            return RedirectToAction("Index");
        }
    }
}