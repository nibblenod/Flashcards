using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Spectre.Console;
using Flashcards.Models;
using Flashcards.DTOs;
namespace Flashcards
{
    internal class StackController
    {
        DatabaseManager dbManager = new();
        internal void ViewStacks()
        {
            using (var connection = new SqlConnection(dbManager.connectionStringWithDB))
            {
                var sql = "SELECT * FROM Stacks;";

                var results = connection.Query<StackModel>(sql).ToList();


                //Converting List of StackModel Objects to StackDTO Objects.
                List<StackDTO> dtoResults = new List<StackDTO>();
                foreach (var result in results)
                {
                    StackDTO stackDTO = DTOMapper.toStackDTO(result);
                    dtoResults.Add(stackDTO);
                }


                var table = new Table();
                table.ShowRowSeparators();

                table.AddColumn(new TableColumn("Name").Centered());

                foreach (StackDTO result in dtoResults)
                {
                    table.AddRow($"{result.Name}");
                }

                AnsiConsole.Write(table);
                //table.AddColumn("")
               
            }
        }
    }
}
