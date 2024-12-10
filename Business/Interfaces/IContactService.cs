using Business.Models;

namespace Business.Interfaces;

public interface IContactService
{
    void CreateContact(Contact contact);
    IEnumerable<Contact> GetAllContacts();
}
