using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flashcards.DTOs;
using Spectre.Console;

namespace Flashcards
{
    internal static class UI
    {

        internal static string StackSelector(List<StackDTO> dtoResults)
        {

            Table table = new Table();
            table.ShowRowSeparators();

            table.AddColumn("Name");
            
            foreach (var result in dtoResults)
            {
                table.AddRow($"{result.Name}");
            }

            AnsiConsole.Write(table);

            string stackName = AnsiConsole.Prompt(new TextPrompt<string>("Enter the name of the stack you want to select: "));

            while (!Validator.StackValidator(stackName, dtoResults))
            {
                stackName = AnsiConsole.Prompt(new TextPrompt<string>("Invalid Stack Name! Enter again: "));
            }

            return stackName;
          
        }

       
    }
}
