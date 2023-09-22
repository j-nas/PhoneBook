using PhoneBook.Controllers;
using PhoneBook.Models;
using Spectre.Console;

namespace PhoneBook.Services;

internal static class ContactService
{
    public static void ListContacts()
    {
        var contacts = ContactController.ListContacts();
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Phone");
        table.AddColumn("Email");

        foreach (var contact in contacts)
        {
            table.AddRow(contact.ContactId.ToString(), contact.Name, contact.Phone, contact.Email);
        }

        AnsiConsole.Write(table);
        Console.ReadKey();
    }

    public static void InsertContact()
    {
        var contact = new Contact();
        contact.Name = AnsiConsole.Ask<string>("Enter contact name");
        contact.Phone = AnsiConsole.Ask<string>("Enter contact phone");
        contact.Email = AnsiConsole.Ask<string>("Enter contact email");
        
        ContactController.AddContact(contact);
    }

    public static void SearchContacts()
    {
        throw new NotImplementedException();
    }
}