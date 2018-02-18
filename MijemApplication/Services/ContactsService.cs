using System.Collections.Generic;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MijemApplication.Models;
using MijemApplication.ViewModels;

namespace MijemApplication.Services.ContactsService
{
    public class ContactsService : IContactsService
    {
        private MijemTestEntities _db = new MijemTestEntities();

        public List<ContactsViewModel> GetAllContacts()
        {
            var contacts = _db.Contacts.Select(o => new ContactsViewModel
            {
                ContactId = o.ContactID,
                ContactName = o.ContactName,
                PhoneNumber = o.PhoneNumber,
                BirthDate = o.BirthDate,
                ContactTypeId = o.ContactType1.TypeID,
                TypeDescription = o.ContactType1.TypeDescription,
                TypeName = o.ContactType1.TypeName
        }).ToList();
            return contacts;
        }
    }
}
