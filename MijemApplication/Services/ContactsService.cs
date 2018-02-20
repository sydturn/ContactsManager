using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using MijemApplication.ViewModels;

namespace MijemApplication.Services
{
    public class ContactsService : IContactsService
    {
        private readonly MijemTestEntities _db = new MijemTestEntities();

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
                BirthDate = o.BirthDate,
                ContactType = o.ContactType,
                FilePath = o.Description,
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
            //create a unique file name/path and store it in the database so we can find it
            //most of the data entered into the rich text editor is too large to store in a varchar
            string path = $@"{DateTime.Now.Ticks}.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write(vm.Description);
                    sw.Close();
                }
            }
            _db.CreateContact(vm.ContactId, vm.ContactName, vm.PhoneNumber, vm.BirthDate, vm.ContactType, path);
            _db.SaveChanges();
        }

        /// <summary>
        /// deletes a contact based on id
        /// </summary>
        /// <param name="id">takes in the id of the contact being deleted</param>
        public void DeleteContactById(int id)
        {
            _db.DeleteContactById(id);
            _db.SaveChanges();
        }

        /// <summary>
        /// updates a pre-existing entry in the contacts table
        /// </summary>
        /// <param name="vm">vm is the contact being edited</param>
        public void UpdateContactInfo(ContactsViewModel vm)
        {
            //Remove the old file and make a new one with the description stored in it
            File.Delete(vm.FilePath);
            string path = $@"{DateTime.Now.Ticks}.txt";
            if (!File.Exists(path))
            {
                File.WriteAllText(path, vm.Description);
            }
            _db.UpdateContactInfo(vm.ContactId, vm.ContactName, vm.PhoneNumber, vm.BirthDate, vm.ContactType, path);
            _db.SaveChanges();
        }
        
        /// <summary>
        /// Get's contact from the contac table based on an id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns a contact in the form of a contact viewmodel</returns>
        public ContactsViewModel GetContactById(int id)
        {
            var contact = _db.GetContactById(id).Select(o => new ContactsViewModel
            {
                ContactId = o.ContactID,
                ContactName = o.ContactName,
                PhoneNumber = o.PhoneNumber,
                BirthDate = o.BirthDate,
                ContactType = o.ContactType,
                FilePath = o.Description
            }).First();
            contact.Description = File.ReadAllText(contact.FilePath);
            return contact;
        }
    }
}
