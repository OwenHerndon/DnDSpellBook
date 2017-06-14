using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DnDSpellBook.Models;
using System.Data;
using Dapper;

namespace DnDSpellBook.DAL
{
    public class AddCharacterRepository : IAddCharacterRepository
    {
            readonly IDbConnection _dbConnection;

            public AddCharacterRepository(IDbConnection connection)
            {
                _dbConnection = connection;
            }

            public void Save(Character newCharacter)
            {
                var sql = @"Insert into Character(Name)
                        Values(@Name)";

                _dbConnection.Execute(sql, newCharacter);
            }
        }
}