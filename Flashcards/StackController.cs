﻿using Dapper;
using Flashcards.DTOs;
using Flashcards.Models;
using Microsoft.Data.SqlClient;
namespace Flashcards
{
    internal class StackController
    {
        DatabaseManager dbManager = new();

        internal (bool, string?) CreateStack(string stackName)
        {
            using (var connection = new SqlConnection(dbManager.connectionStringWithDB))
            {
                var sql = $"INSERT INTO Stacks VALUES('{stackName}')";

                try
                {
                    connection.Execute(sql);
                    return (true, null);
                }

                catch (Exception ex)
                {
                    return (false, ex.Message);
                }
            }
        }

        internal (bool, string?) EditStack(int id, string stackName)
        {
            using (var connection = new SqlConnection(dbManager.connectionStringWithDB))
            {
                int originalID = DTOMapper.StackIDMap[id];
                var sql = $"UPDATE Stacks SET NAME = '{stackName}' where ID = {originalID}";

                try
                {
                    connection.Execute(sql);
                    return (true, null);
                }

                catch (Exception ex)
                {
                    return (false, ex.Message);
                }

            }
        }

        internal (bool, string?) RemoveStack(int id)
        {
            using (var connection = new SqlConnection(dbManager.connectionStringWithDB))
            {
                int originalID = DTOMapper.StackIDMap[id];
                var sql = $"DELETE FROM Stacks WHERE ID = {originalID}";

                try
                {
                    connection.Execute(sql);
                    return (true, null);
                }

                catch (Exception ex)
                {
                    return (false, ex.Message);
                }

            }
        }
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
                    StackDTO stackDTO = DTOMapper.toStackDTO(result, dtoID);
                    dtoID++;
                    dtoResults.Add(stackDTO);
                }

                return dtoResults;

            }
        }
    }
}
