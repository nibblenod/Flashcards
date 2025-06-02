using Dapper;
using Flashcards.DTOs;
using Flashcards.Models;
using Microsoft.Data.SqlClient;
namespace Flashcards
{
    internal class StackController
    {
        DatabaseManager dbManager = new();
        internal List<StackDTO> ViewStacks()
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

                return dtoResults;

            }
        }
    }
}
