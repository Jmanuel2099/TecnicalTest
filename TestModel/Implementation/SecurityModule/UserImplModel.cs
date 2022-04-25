using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModel.DbModel.SecurityModule;
using TestModel.TestDataBase;

namespace TestModel.Implementation.SecurityModule
{
    /// <summary>
    /// This class implements queries in data base and CRUD user
    /// </summary>
    public class UserImplModel
    {
        private Connection _connetion;

        public UserImplModel() 
        {
            _connetion = new Connection();
        }

        /// <summary>
        /// This method gets the user records from the USER_ table
        /// </summary>
        /// <returns>
        /// IEnumerable of type User whit records returned by the SQL query
        /// </returns>
        public async Task<IEnumerable<UserDbModel>> RecordUserList()
        { 
            var db = _connetion.makeConnection();
            db.Open();
            var sql = @"
                        SELECT *
                        FROM ""Test"".""User_"" 
                        ";
            return await db.QueryAsync<UserDbModel>(sql, new { });
        }

        /// <summary>
        /// This method looks a user whit filter id
        /// </summary>
        /// <param name="id">Filter that is used to make SQL query</param>
        /// <returns>
        /// User objet
        /// </returns>
        public async Task<UserDbModel> RecordUserById(int id)
        {
            var db = _connetion.makeConnection();
            db.Open();
            var sql = @"
                        SELECT ""FIRSTNAME"" 
                        FROM ""Test"".""User_"" WHERE ""Id"" = @Id";
            return await db.QueryFirstOrDefaultAsync<UserDbModel>(sql, new {Id = id });
        }
    }
}
