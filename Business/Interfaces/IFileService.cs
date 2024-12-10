namespace Business.Interfaces;

public interface IFileService
{
    string GetContentFromFile();
    void SaveToFile(string content);
}
