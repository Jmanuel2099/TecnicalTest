using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModel.DbModel.Data;
using TestModel.DbModel.ParametersModule;
using TestModel.TestDataBase;

namespace TestModel.Implementation.ParametersModule
{
    /// <summary>
    /// This class implements queries in data base and CRUD order.
    /// </summary>
    public class OrderImpModel
    {
        private Connection _connection;

        public OrderImpModel()
        {
            _connection = new Connection();
        }

        /// <summary>
        /// This method inserts a record in ORDER table  
        /// </summary>
        /// <param name="model"> orden model to be insert in ORDER table</param>
        /// <returns>
        /// True if the record inserted succesfull,
        /// Flase if the record inserted unsuccesfull
        /// </returns>
        public async Task<bool> RecordOrdenCreation(OrderDbModel model)
        {
            var userId = model.UserId;
            var date = model.Date;
            var db = _connection.makeConnection();
            db.Open();
            var sql = @"INSERT INTO ""Test"".""ORDER"" (""DATE"", ""USERID"")
                        VALUES (@Date, @UserId)
                        ";
            var result = await db.ExecuteAsync(sql, new { Date = date, UserId = userId });
            db.Close();
            ItemOrderDbModel itemOrderModel;
            foreach (var item in model.ItemIdList.Distinct())
            {
                itemOrderModel = new ItemOrderDbModel
                {
                    IdOrder = getIdLastOrder(),
                    IdItem = item,
                    Quantity = getQuantity(model.ItemIdList, item)
                };
                await RecordOrdenItem(itemOrderModel);
            }
            return result > 0;
        }

        /// <summary>
        /// This method insets record in ORDERITEM table
        /// </summary>
        /// <param name="model"> itemOrder model to be te insert</param>
        /// <returns> 
        /// True if the record inserted succesfull,
        /// Flase if the record inserted unsuccesfull
        /// </returns>
        public async Task<bool> RecordOrdenItem(ItemOrderDbModel model)
        {
            var idItem = model.IdItem;
            var idOrder = model.IdOrder;
            var quantity = model.Quantity;
            var db = _connection.makeConnection();
            db.Open();
            var sql = @"INSERT INTO ""Test"".""ORDERITEM"" (""IDORDER"", ""IDITEM"", ""QUANTITTY"")
                        VALUES  (@IdOrder, @IdItem, @Quantity)
                        ";
            var result = await db.ExecuteAsync(sql, new
            {
                IdOrder = idOrder,
                IdItem = idItem,
                Quantity = quantity
            });
            db.Close();
            return result > 0;
        }

        public async Task<IEnumerable<ItemOrderByUser>> getItemsOrder(int id)
        {
            var db = _connection.makeConnection();
            db.Open();
            var sql = @"
            SELECT ""ORDERITEM"".""IDORDER"", ""ORDERITEM"".""IDITEM"", ""NAME"",
            ""ITEM"".""DESCRIPTION"", ""ITEM"".""IMAGE"", ""ORDERITEM"".""QUANTITTY"" as Quantity
            FROM ""Test"".""ORDERITEM""  JOIN ""Test"".""ITEM""
            ON ""Test"".""ORDERITEM"".""IDITEM"" = ""Test"".""ITEM"".""Id""
            WHERE ""ORDERITEM"".""IDORDER"" IN
            (SELECT ""Id"" FROM ""Test"".""ORDER"" WHERE ""USERID"" = @Id);
            ";
            return await db.QueryAsync<ItemOrderByUser>(sql, new { Id = id });
        }

        /// <summary>
        /// This method gets the quantity a item is on an order
        /// </summary>
        /// <param name="list">items list that have a order</param>
        /// <param name="id"> id item to be the search </param>
        /// <returns>quantity that an item is in the order</returns>
        public int getQuantity(List<int> list, int id) 
        {
            var numberRepetitions = 0;
            foreach (var item in list)
            {
                if (item.Equals(id))
                {
                    numberRepetitions ++;
                }
            }
            return numberRepetitions;
        }

        /// <summary>
        /// This method looks the id that have a last order.
        /// </summary>
        /// <returns>id that have a last order </returns>
        public int getIdLastOrder() 
        {
            var db = _connection.makeConnection();
            db.Open();
            var sql = @"SELECT MAX(""Id"") 
                        FROM ""Test"".""ORDER"" ";

            int max =  db.ExecuteScalar<int>(sql);
            db.Close();
            return max;
        }

    }
}
