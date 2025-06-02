using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Spectre.Console;
using Flashcards.Models;
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

                var results = connection.Query<Stack>(sql).ToList();

                var table = new Table();

                //table.AddColumn("")
                foreach (var result in results)
                {
                    //table.AddColumn()
                    Console.WriteLine($"{result.Id} {result.Name}");
                }
            }
        }
    }
}
