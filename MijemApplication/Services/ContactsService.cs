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

        /// <summary>
        /// gets all contacts from the contact table
        /// </summary>
        /// <returns>returns a list of contacts from the contacts table</returns>
        public List<ContactsViewModel> GetAllContacts()
        {
            var contacts = _db.GetAllContacts().Select(o => new ContactsViewModel
            {
                ContactName = o.ContactName,
                ContactId = o.ContactID,
                PhoneNumber = o.PhoneNumber,
                ContactType = o.ContactType,
                Description = o.Description,
                TypeName = _db.GetTypeById(o.ContactType).Select(x => x.TypeName).First()
            }).ToList();
            return contacts;
        }

        /// <summary>
        /// creates a new entry in the Contacts table
        /// </summary>
        /// <param name="vm">takes in contact information in the form of ContactsViewModel</param>
        public void CreateContact(ContactsViewModel vm)
        {
            _db.CreateContact(vm.ContactId, vm.TypeName, vm.PhoneNumber, vm.BirthDate, vm.ContactType, vm.Description);
        }

        /// <summary>
        /// deletes a contact based on id
        /// </summary>
        /// <param name="id">takes in the id of the contact being deleted</param>
        public void DeleteContactById(int id)
        {
            _db.DeleteContactById(id);
        }

        /// <summary>
        /// gets all types from the contactTypes table
        /// </summary>
        /// <returns>returns a list of types</returns>
        public List<TypeViewModel> GetAllTypes()
        {
            return _db.GetAllTypes().Select(o => new TypeViewModel
            {
                TypeID = o.TypeID,
                TypeName = o.TypeName,
            }).ToList();
        }
        /// <summary>
        /// updates a pre-existing entry in the contacts table
        /// </summary>
        /// <param name="vm">vm is the contact being edited</param>
        public void UpdateContactInfo(ContactsViewModel vm)
        {
            _db.UpdateContactInfo(vm.ContactId, vm.ContactName, vm.PhoneNumber, vm.BirthDate, vm.ContactType, vm.Description);
        }

        /// <summary>
        /// takes in a type and updates the corresponding entry in the contact types table
        /// </summary>
        /// <param name="vm">takes in typeviewmodel</param>
        public void UpdateContactType(TypeViewModel vm)
        {
            _db.UpdateContactType(vm.TypeID, vm.TypeName);
        }        
    }
}
