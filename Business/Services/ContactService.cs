using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class ContactService(IFileService fileService) : IContactService
{
    private readonly IFileService _fileService = fileService;
    private List<Contact> _contacts = [];


    #region Methods

    public void CreateContact(Contact contact)
    {
        contact.Id = Guid.NewGuid().ToString();
        _contacts.Add(contact);
        _fileService.SaveToFile(_contacts);
    }

    public IEnumerable<Contact> GetAllContacts()
    {
        try
        {
            _contacts = _fileService.GetContentFromFile()!;
        }
        catch
        {
            _contacts = [];
        }

        return _contacts;
    }


    #endregion
}
