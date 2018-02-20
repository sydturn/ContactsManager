﻿using System.Web.Mvc;
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
        // GET: Contacts
        public ActionResult Index()
        {
            var contacts = _contactsService.GetAllContacts();
            return View(contacts);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            ViewBag.ContactType = new SelectList(_db.ContactTypes, "TypeID", "TypeName");
            return View();
        }

        // POST: Contacts/Create
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

        // GET: Contacts/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var contact = _contactsService.GetContactById(id);
            ViewBag.ContactType = new SelectList(_db.ContactTypes, "TypeID", "TypeName", contact.ContactType);
            return View(contact);
        }

        // POST: Contacts/Edit/5
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
