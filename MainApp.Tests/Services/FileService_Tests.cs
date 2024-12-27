using Business.Models;
using Business.Services;
using System.Text.Json;

namespace MainApp.Tests.Services;

public class FileService_Tests
{
    [Fact]
    /* Detta är genererat av ChatGPT 4o.
     Koden skapar ett test på SaveToFile-funktionen i FileService.cs.
     Jag genererade denna för att få hjälp att förstå hur jag gör ett test på något som vill skapa data.
    
    Den här koden skapar först dummy-data istället för att använda sig av den riktiga datan.
    Sen skapar den ett resultat och kollar om det är True att datan sparas i filen.
    Och raderar sen allt när det är klart.
     */

    public void SaveToFile_ShouldReturnTrue_IfDataIsSavedToFile()
    {
        // arrange
        var directoryPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        var filePath = Path.Combine(directoryPath, "fakecontacts.json");
        var jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };

        var fileService = new FileService(directoryPath, "fakecontacts.json");

        var contacts = new List<Contact>
        {
            new Contact
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Alice",
                LastName = "Smith",
                Email = "alice.smith@example.com",
                Phone = "1234567890",
                StreetAddress = "123 Main St",
                ZipCode = "12345",
                City = "Metropolis"
            },
            new Contact
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Bob",
                LastName = "Johnson",
                Email = "bob.johnson@example.com",
                Phone = "0987654321",
                StreetAddress = "456 Elm St",
                ZipCode = "67890",
                City = "Gotham"
            }
        };

        // act
        var result = fileService.SaveToFile(contacts);


        // assert
        Assert.True(result);
        Assert.True(File.Exists(filePath), "File should be created");

        var savedContent = File.ReadAllText(filePath);
        Assert.Contains("Alice", savedContent);
        Assert.Contains("Smith", savedContent);
        Assert.Contains("Bob", savedContent);
        Assert.Contains("Johnson", savedContent);

        // cleanup
        if (Directory.Exists(directoryPath))
        {
            Directory.Delete(directoryPath, true);
        }
    }

    [Fact]
    public void GetContentFromFile_ShouldReturnListWithContacts_IfContainsDataInList()
    {
        // arrange
        var directoryPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        var filePath = Path.Combine(directoryPath, "fakecontacts.json");
        var jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };

        var fileService = new FileService(directoryPath, "fakecontacts.json");

        var contacts = new List<Contact>
        {
            new Contact
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Alice",
                LastName = "Smith",
                Email = "alice.smith@example.com",
                Phone = "1234567890",
                StreetAddress = "123 Main St",
                ZipCode = "12345",
                City = "Metropolis"
            },
            new Contact
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Bob",
                LastName = "Johnson",
                Email = "bob.johnson@example.com",
                Phone = "0987654321",
                StreetAddress = "456 Elm St",
                ZipCode = "67890",
                City = "Gotham"
            }
        };

        fileService.SaveToFile(contacts);

        // act
        var result = fileService.GetContentFromFile();

        // assert
        Assert.NotEmpty(result);

        // cleanup
        if (Directory.Exists(directoryPath))
        {
            Directory.Delete(directoryPath, true);
        }

    }

    [Fact]
    public void GetContentFromFile_ShouldReturnEmptyList_IfNoDataInList()
    {
        // arrange
        var directoryPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        var filePath = Path.Combine(directoryPath, "fakecontacts.json");
        var jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };

        var fileService = new FileService(directoryPath, "fakecontacts.json");

        // act
        var result = fileService.GetContentFromFile();
        
        // assert
        Assert.Empty(result);
        
        // cleanup
        if (Directory.Exists(directoryPath))
        {
            Directory.Delete(directoryPath, true);
        }
    }
}
