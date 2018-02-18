using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MijemApplication.Models;
using MijemApplication.Services.ContactsService;
using MijemApplication.ViewModels;

namespace MijemApplication.Controllers
{
    public class ContactsController : Controller
    {
        private MijemTestEntities db = new MijemTestEntities();
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
            ViewBag.ContactType = new SelectList(db.ContactTypes, "TypeID", "TypeName");
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ContactID,ContactName,PhoneNumber,BirthDate,ContactType")] ContactsViewModel contact)
        {
            if (ModelState.IsValid)
            {
                _contactsService.CreateContact(contact);
                return RedirectToAction("Index");
            }

            ViewBag.ContactType = new SelectList(db.ContactTypes, "TypeID", "TypeName", contact.ContactType);
            return View(contact);
        }

        // GET: Contacts/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var contact = _contactsService.GetContactById(id);
            ViewBag.ContactType = new SelectList(db.ContactTypes, "TypeID", "TypeName", contact.ContactType);
            return View(contact);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ContactID,ContactName,PhoneNumber,BirthDate,ContactType,Description")] ContactsViewModel contact)
        {
            if (ModelState.IsValid)
            {
                _contactsService.UpdateContactInfo(contact);
                return RedirectToAction("Index");
            }
            ViewBag.ContactType = new SelectList(db.ContactTypes, "TypeID", "TypeName", contact.ContactType);
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _contactsService.DeleteContactById(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
