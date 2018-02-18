using System.Collections.Generic;
using MijemApplication.ViewModels;

namespace MijemApplication.Services.ContactsService
{
    public interface IContactsService
    {
        List<ContactsViewModel> GetAllContacts();
        ContactsViewModel GetContactById(int id);
        void UpdateContactInfo(ContactsViewModel vm);
        void CreateContact(ContactsViewModel vm);
        void DeleteContactById(int id);
    }
}
