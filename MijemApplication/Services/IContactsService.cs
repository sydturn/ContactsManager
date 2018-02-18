using System.Collections.Generic;
using MijemApplication.ViewModels;

namespace MijemApplication.Services.ContactsService
{
    public interface IContactsService
    {
        List<ContactsViewModel> GetAllContacts();
    }
}
