using System.Web.Mvc;
using MijemApplication.ViewModels;
using MijemApplication.Services;

namespace MijemApplication.Controllers
{
    public class ContactsController : Controller
    {
        private readonly MijemTestEntities _db = new MijemTestEntities();
        private readonly IContactsService _contactsService;

        public ContactsController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }
        // Return primary contacts page (list of contacts)
        public ActionResult Index()
        {
            var contacts = _contactsService.GetAllContacts();
            return View(contacts);
        }

        // Brings user to the create page
        public ActionResult Create()
        {
            ViewBag.ContactType = new SelectList(_db.ContactTypes, "TypeID", "TypeName");
            return View();
        }

        // Creates a contact in the contact table and returns user to contact list page
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ContactID,ContactName,PhoneNumber,BirthDate,ContactType,Description")] ContactsViewModel contact)
        {
            if (ModelState.IsValid)
            {
                _contactsService.CreateContact(contact);
                return RedirectToAction("Index");
            }

            ViewBag.ContactType = new SelectList(_db.ContactTypes, "TypeID", "TypeName", contact.ContactType);
            return View(contact);
        }

        // Brings user to the edit page for specified contact
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var contact = _contactsService.GetContactById(id);
            ViewBag.ContactType = new SelectList(_db.ContactTypes, "TypeID", "TypeName", contact.ContactType);
            return View(contact);
        }

        // Saves edites to contact entry in contacts table and returns user to contact list page
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ContactID,ContactName,PhoneNumber,BirthDate,ContactType,Description,FilePath")] ContactsViewModel contact)
        {
            if (ModelState.IsValid)
            {
                _contactsService.UpdateContactInfo(contact);
                return RedirectToAction("Index");
            }
            ViewBag.ContactType = new SelectList(_db.ContactTypes, "TypeID", "TypeName", contact.ContactType);
            return View(contact);
        }

        //deletes a user from the contact table based on the specified user id
        public ActionResult DeleteConfirmed(int id)
        {
            _contactsService.DeleteContactById(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
