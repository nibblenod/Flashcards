using Dapper;
using Flashcards.DTOs;
using Flashcards.Models;
using Microsoft.Data.SqlClient;
namespace Flashcards
{
    internal class StackController
    {
        DatabaseManager dbManager = new();
        DTOMapper dtoMapper = new();
        internal List<StackDTO> GiveStacks()
        {
            using (var connection = new SqlConnection(dbManager.connectionStringWithDB))
            {
                
                var sql = "SELECT * FROM Stacks;";

                var results = connection.Query<StackModel>(sql).ToList();

                //Converting List of StackModel Objects to StackDTO Objects.
                List<StackDTO> dtoResults = new List<StackDTO>();

                int dtoID = 1;
                foreach (var result in results)
                {
                    StackDTO stackDTO = dtoMapper.toStackDTO(result, dtoID);
                    dtoID++;
                    dtoResults.Add(stackDTO);
                }

                return dtoResults;

            }
        }
    }
}
