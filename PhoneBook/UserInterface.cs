using PhoneBook.Services;
using Spectre.Console;
using static PhoneBook.Enums;

namespace PhoneBook;

internal static class UserInterface
{
    internal static void Title()
    {
        AnsiConsole.Write(new FigletText("Phonebook").Color(Color.Green));
    }

    internal static void MainMenu()
    {
        var isAppRunning = true;

        while (isAppRunning)
        {
            Console.Clear();
            Title();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MainMenuOptions>()
                    .Title("Main Menu")
                    .AddChoices(MainMenuOptions.ListContacts,
                        MainMenuOptions.SearchContacts,
                        MainMenuOptions.AddContact,
                        MainMenuOptions.Quit));

            switch (option)
            {
                case MainMenuOptions.ListContacts:
                    ContactService.ListContacts();
                    break;
                case MainMenuOptions.SearchContacts:
                    ContactService.SearchContacts();
                    break;
                case MainMenuOptions.AddContact:
                    ContactService.InsertContact();
                    break;
                case MainMenuOptions.Quit:
                    isAppRunning = false;
                    break;
            }
        }
    }
}