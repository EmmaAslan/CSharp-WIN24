using Business.Models;

namespace Business.Interfaces;

public interface IFileService
{
    List<Contact> GetContentFromFile();

    bool SaveToFile(List<Contact> content);
}
