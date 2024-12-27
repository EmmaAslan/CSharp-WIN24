using Business.Interfaces;
using Business.Models;
using MainApp.Interfaces;

namespace MainApp.Dialogs;

public class MainMenuDialog(IContactService contactService) : IMainMenuDialog
{
    private readonly IContactService _contactService = contactService;

    public void ShowMenuOptions()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("----- MAIN MENU - CONTACT MANAGEMENT -----");
            Console.WriteLine("1. Create New Contact");
            Console.WriteLine("2. View All Contacts");
            Console.WriteLine("---------------------------");
            Console.Write("Enter option: ");
            var option = Console.ReadLine();


            switch (option)
            {
                case "1":
                    CreateContactOption();
                    break;

                case "2":
                    ViewAllContactsOption();
                    break;
            }
        }
    }

    public void CreateContactOption()
    {
        var contact = new Contact();

        Console.Clear();
        Console.WriteLine("----- CREATE NEW CONTACT -----");
        Console.Write("Enter First Name: ");
        contact.FirstName = Console.ReadLine()!;

        Console.Write("Enter Last Name: ");
        contact.LastName = Console.ReadLine()!;

        Console.Write("Enter Email: ");
        contact.Email = Console.ReadLine()!;

        Console.Write("Enter Phone Number: ");
        contact.Phone = Console.ReadLine()!;

        Console.Write("Enter Street Address: ");
        contact.StreetAddress = Console.ReadLine()!;

        Console.Write("Enter Zip Code: ");
        contact.ZipCode = Console.ReadLine()!;

        Console.Write("Enter City: ");
        contact.City = Console.ReadLine()!;

        _contactService.CreateContact(contact);

    }

    public void ViewAllContactsOption()
    {
        Console.Clear();
        Console.WriteLine("----- ALL CONTACTS -----");

        foreach (var contact in _contactService.GetAllContacts())
        {
            Console.WriteLine($"Name: {contact.FirstName} {contact.LastName} \nEmail: {contact.Email} \nPhone Number: {contact.Phone}\nAddress: {contact.StreetAddress}, {contact.ZipCode} {contact.City}");
            Console.WriteLine("\n-----------\n");
        }

        Console.WriteLine("Press any key to go back to Main Menu");
        Console.ReadKey();
    }





}
