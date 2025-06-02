using Spectre.Console;
using static Flashcards.Enums;
using Flashcards.DTOs;
namespace Flashcards
{
    internal abstract class Menu
    {
        protected bool exitApp = false;
        internal abstract void PrintMenu();
    }

    internal class MainMenu : Menu
    {
        StackController stackController = new();
        internal override void PrintMenu()
        {
            Console.Clear();
            while (!exitApp)
            {
                MainMenuOptions userSelection = AnsiConsole.Prompt(new SelectionPrompt<MainMenuOptions>().Title("What do you want to do?").
                    AddChoices(Enum.GetValues<MainMenuOptions>()));
                switch (userSelection)
                {
                    case MainMenuOptions.Exit:
                        exitApp = true;
                        break;
                    case MainMenuOptions.ManageStacks:
                        List<StackDTO> stackResults = stackController.ViewStacks();
                        string stackName = UI.StackSelector(stackResults);

                        StackManagementMenu menu = new(stackName);
                        menu.PrintMenu();
                        break;
                  
                }
            }
        }

    internal class StackManagementMenu : Menu
        {
            string stackName;

            internal StackManagementMenu(string name)
            {
                stackName = name;
            }
            internal override void PrintMenu()
            {
                while (!exitApp)
                {
                    StackManagementOptions userSelection = AnsiConsole.Prompt(new SelectionPrompt<StackManagementOptions>().Title($"Current working stack: {stackName}").
                    AddChoices(Enum.GetValues<StackManagementOptions>()));

                    switch (userSelection)
                    {
                        case StackManagementOptions.MainMenu:
                            exitApp = true;
                            break;
                    }
                }
            }
        }

    }
    
}
