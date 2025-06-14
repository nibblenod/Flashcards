using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Flashcards.DTOs;
using Spectre.Console;
using static Flashcards.Enums;

namespace Flashcards
{
    internal static class UI
    {

        internal static string StackSelector(List<StackDTO> dtoResults)
        {

            ShowStacks(dtoResults);

            string stackName = AnsiConsole.Prompt(new TextPrompt<string>("Enter the name of the stack you want to select: "));

            while (!Validator.StackValidator(stackName, dtoResults))
            {
                stackName = AnsiConsole.Prompt(new TextPrompt<string>("Invalid Stack Name! Enter again: "));
            }

            return stackName;
        }

        internal static (string, EditType) AskForUpdateValue()
        {

            return (AnsiConsole.Prompt(new TextPrompt<string>("Enter the new value: ")), AnsiConsole.Prompt(new SelectionPrompt<EditType>()
                        .Title("Update Type")
                        .AddChoices(Enum.GetValues<EditType>())));
                     
        }

        internal static int FlashcardSelector(List<FlashcardDTO> dtoResults)
        {
            ShowFlashcards(dtoResults);

            int id = AnsiConsole.Prompt(new TextPrompt<int>("Enter the id of the flashcard you want to select: "));

            while (!Validator.FlashcardValidator(id, dtoResults))
            {
                id = AnsiConsole.Prompt(new TextPrompt<int>("Wrong id entered! Enter the id of the flashcard you want to select: "));
            }

            return id;
        }

        private static void ShowStacks(List<StackDTO> stacks)
        {
            Table table = new Table();
            table.ShowRowSeparators();

            table.AddColumn("Name");

            foreach (var result in stacks)
            {
                table.AddRow($"{result.Name}");
            }

            AnsiConsole.Write(table);
        }

        internal static void ShowFlashcards(List<FlashcardDTO> flashcards, int numberOfFlashcards = -1)
        {
            Table table = new Table();
            table.ShowRowSeparators();

            table.AddColumn("ID");
            table.AddColumn("Front");
            table.AddColumn("Back");

            foreach (var result in flashcards)
            {
                table.AddRow(result.ID.ToString(), result.Front, result.Back);
                if (numberOfFlashcards == result.ID) break;
            }

            AnsiConsole.Write(table);
        }

        internal static (string, string) CreateFlashcard()
        {
            string front = AnsiConsole.Prompt(new TextPrompt<string>("Enter the content for front of the flashcard: "));
            string back = AnsiConsole.Prompt(new TextPrompt<string>("Enter the content for back of the flashcard: "));

            return (front, back);
        }

    }
}
