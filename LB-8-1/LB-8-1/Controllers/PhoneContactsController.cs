using System.Threading.Tasks;
using LB_8_1.Models;
using LB_8_1.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LB_8_1.Controllers
{
    public class PhoneContactsController : Controller
    {
        private readonly IPhoneContactsRepository _phoneContactsRepository;

        public PhoneContactsController(IPhoneContactsRepository phoneContactsRepository)
        {
            _phoneContactsRepository = phoneContactsRepository;
        }
        
        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var contacts = await _phoneContactsRepository.GetPhoneContacts();
            
            return View(contacts);
        }

        [HttpGet]
        public IActionResult AddContactView()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddContact(PhoneContact phoneContact)
        {
            await _phoneContactsRepository.AddPhoneContact(phoneContact);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateContactView(PhoneContact phoneContact)
        {
            return View(phoneContact);
        }
        
        [HttpPost]
        public async Task<IActionResult> UpdateContact(PhoneContact phoneContact)
        {
            await _phoneContactsRepository.UpdatePhoneContact(phoneContact);
            
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult RemoveContactView(PhoneContact phoneContact)
        {
            return View(phoneContact.Id);
        }
        
        [HttpPost]
        public async Task<IActionResult> RemoveContact(int id)
        {
            await _phoneContactsRepository.RemovePhoneContact(id);
            
            return RedirectToAction("Index");
        }
    }
}