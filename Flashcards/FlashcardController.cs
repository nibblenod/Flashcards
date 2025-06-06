using Dapper;
using Flashcards.DTOs;
using Flashcards.Models;
using Microsoft.Data.SqlClient;

namespace Flashcards
{
    internal class FlashcardController
    {
        DatabaseManager dbManager = new();

        internal List<FlashcardDTO> GiveStackFlashcards(string name)
        {
            //Retrieve the ID of the Stack Name

            string id = GetIDOfStack(name);

            string command = $"SELECT * FROM Flashcards WHERE StackID = {id}";

            using (var connection = new SqlConnection(dbManager.connectionStringWithDB))
            {
                var results = connection.Query<Flashcard>(command);

                List<FlashcardDTO> flashcardDTOs = new();
                //Convert into DTO
                foreach (var result in results)
                {
                    flashcardDTOs.Add(DTOMapper.toFlashcardDTO(result));
                }

                return flashcardDTOs;
            }
        }

        internal void EditFlashcard(int id, List<FlashcardDTO> flashcards)
        {
            string front = flashcards[id - 1].Front;

        }

        internal void DeleteFlashcard(int id, List<FlashcardDTO> flashcards)
        {
            string front = flashcards[id - 1].Front;

            using (var connection = new SqlConnection(dbManager.connectionStringWithDB))
            {
                var command = $"DELETE FROM Flashcards WHERE front = '{front}'";
                connection.Execute(command);
            }

        }



        private string GetIDOfStack(string name)
        {

            using (var connection = new SqlConnection(dbManager.connectionStringWithDB))
            {
                string command = @$"SELECT ID from Stacks where Name = '{name}'";

                string id = connection.ExecuteScalar<string>(command);

                return id;
            }
        }

        
    }
}
