using Spectre.Console;
using static Flashcards.Enums;
using Flashcards.DTOs;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
namespace Flashcards
{
    internal abstract class Menu
    {
        protected bool exitApp = false;
        protected StackController stackController = new();
        protected FlashcardController flashcardController = new();

        internal abstract void PrintMenu();
    }

    internal class MainMenu : Menu
    {
        internal override void PrintMenu()
        {
            while (!exitApp)
            {
                Console.Clear();

                MainMenuOptions userSelection = AnsiConsole.Prompt(new SelectionPrompt<MainMenuOptions>().Title("What do you want to do?").
                    AddChoices(Enum.GetValues<MainMenuOptions>())
                     .UseConverter(option => option.GetAttribute<DisplayAttribute>()?.Name ?? option.ToString())); //? after GetAttribute is to prevent it from throwing exception if it returns NULL. ?? is null coerscing operator that reverts to the right hand side if left is null.
                switch (userSelection)
                {
                    case MainMenuOptions.Exit:
                        exitApp = true;
                        break;
                    case MainMenuOptions.Manage_Stacks:
                        List<StackDTO> stackResults = stackController.GiveStacks();
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
            int id;

            internal StackManagementMenu(string name)
            {
                stackName = name;
            }
            internal override void PrintMenu()
            {

                while (!exitApp)
                {
                    Console.Clear();
                    StackManagementOptions userSelection = AnsiConsole.Prompt(new SelectionPrompt<StackManagementOptions>()
                        .Title($"Current working stack: {stackName}")
                        .AddChoices(Enum.GetValues<StackManagementOptions>())
                        .UseConverter(option => option.GetAttribute<DisplayAttribute>()?.Name ?? option.ToString()));


                    switch (userSelection)
                        {
                        case StackManagementOptions.Main_Menu:
                            exitApp = true;
                            break;

                        case StackManagementOptions.Current_Stack:
                            List<StackDTO> stackResults = stackController.GiveStacks();
                            stackName = UI.StackSelector(stackResults);
                            break;

                        case StackManagementOptions.View_Flashcards:

                            UI.ShowFlashcards(flashcardController.GiveStackFlashcards(stackName));
                            Console.ReadLine();
                 
                            break;
                        case StackManagementOptions.Delete_Flashcard:
                            List<FlashcardDTO> flashcardResults = flashcardController.GiveStackFlashcards(stackName);
                            id = UI.FlashcardSelector(flashcardResults);
                            flashcardController.DeleteFlashcard(id, flashcardResults);
                            AnsiConsole.Markup("[green]Flashcard deleted successfully![/]");
                            Console.ReadLine();
                            break;

                        case StackManagementOptions.View_X_Number_Of_Cards:
                            int numberOfFlashcards = AnsiConsole.Prompt(new TextPrompt<int>("Enter the number of flashcards you want to see: "));
                            UI.ShowFlashcards(flashcardController.GiveStackFlashcards(stackName), numberOfFlashcards);
                            Console.ReadLine();
                            break;

                        case StackManagementOptions.Edit_Flashcard:
                            List<FlashcardDTO> flashCardResults = flashcardController.GiveStackFlashcards(stackName);
                            id = UI.FlashcardSelector(flashCardResults);
                            (string, EditType) updateValuePack = UI.AskForUpdateValue();

                            flashcardController.EditFlashcard(id, flashCardResults, updateValuePack.Item2, updateValuePack.Item1);
                            break;


                    }
                }





            }
        }

    }
    
}
