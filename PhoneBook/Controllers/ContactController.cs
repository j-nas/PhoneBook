using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;

namespace PhoneBook.Controllers;

internal static class ContactController
{
    internal static void AddContact(Contact contact)
    {
        using var db = new PhonebookContext();
        db.Contacts.Add(contact);
        db.SaveChanges();
    }

    internal static void DeleteContact(Contact contact)
    {
        using var db = new PhonebookContext();
        db.Contacts.Remove(contact);
        db.SaveChanges();
    }

    internal static void UpdateContact(Contact contact)
    {
        using var db = new PhonebookContext();
        db.Contacts.Update(contact);
        db.SaveChanges();
    }

    internal static List<Contact> ListContacts()
    {
        using var db = new PhonebookContext();
        return db.Contacts.ToList();
    }

    internal static Contact GetContactById(int id)
    {
        using var db = new PhonebookContext();
        var contact = db.Contacts.Include(x => x.Category)
            .SingleOrDefault(x => x.ContactId == id);

        return contact;
    }
}