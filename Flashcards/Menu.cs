using Spectre.Console;
using static Flashcards.Enums;
namespace Flashcards
{
    internal abstract class Menu
    {
        public abstract void PrintMenu();
    }

    internal class MainMenu : Menu
    {
        StackController stackController = new();
        public override void PrintMenu()
        {
            bool exitApp = false;
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
                        stackController.ViewStacks();
                        break;
                  
                }
            }
        }

    }
    
}
