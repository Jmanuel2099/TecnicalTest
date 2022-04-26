using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModel.DbModel.ParametersModule;

namespace TestModel.TestDataBase.ParametersModule
{
    /// <summary>
    /// This class implements queries in data base and CRUD item
    /// </summary>
    public class ItemImpModel
    {
        Connection _connetion;

        public ItemImpModel() 
        {
            _connetion = new Connection();
        }

        /// <summary>
        /// This method gets the item records from the ITEM table
        /// </summary>
        /// <returns>
        /// IEnumerable of type Item whit records returned by the SQL query
        /// </returns>
        public async Task<IEnumerable<itemDbModel>> RecordItemList()
        {
            var db = _connetion.makeConnection();
            db.Open();
            var sql = @"SELECT ""Id"", ""NAME"", ""DESCRIPTION"", ""IMAGE"", ""REMOVED"" 
                        FROM ""Test"".""ITEM"" WHERE ""REMOVED"" = '0' 
                        ORDER BY ""Id""
                        ";
            return await db.QueryAsync<itemDbModel>(sql, new { });
        }

        /// <summary>
        /// This method looks a item whit filter id
        /// </summary>
        /// <param name="id">Filter that is used to make SQL query</param>
        /// <returns>Item object</returns>
        public async Task<itemDbModel> RecordItemById(int id)
        {
            var db = _connetion.makeConnection();
            db.Open();
            var sql = @"
                        SELECT * 
                        FROM ""Test"".""ITEM"" WHERE ""Id"" = @Id";
            db.Close();
            return await db.QueryFirstOrDefaultAsync<itemDbModel>(sql, new { Id = id });
        }

        public async Task<itemDbModel> RecordItemByName(String itemName)
        {
            var db = _connetion.makeConnection();
            db.Open();
            var sql = @"
                        SELECT * 
                        FROM ""Test"".""ITEM"" WHERE ""NAME"" = @ItemName";
            db.Close();

            return await db.QueryFirstOrDefaultAsync<itemDbModel>(sql, new { ItemName = itemName });

        }


    }
}
