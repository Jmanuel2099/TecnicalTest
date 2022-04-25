using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModel.DbModel.ParametersModule;
using TestModel.TestDataBase;

namespace TestModel.Implementation.ParametersModule
{
    /// <summary>
    /// This class implements queries in data base and CRUD buy.
    /// </summary>
    public class BuyImpModel
    {
        private Connection _connection;

        public BuyImpModel()
        {
            _connection = new Connection();
        }

        /// <summary>
        /// This method inserts a record in BUY table
        /// </summary>
        /// <param name="model">buy model to be insert in BUY table</param>
        /// <returns>
        /// True if the record inserted succesfull,
        /// Flase if the record inserted unsuccesfull
        /// </returns>
        public async Task<bool> recordBuyCreation(BuyDbModel model)
        {
            var orderId = model.OrderId;
            var date = model.Date;
            var db = _connection.makeConnection();
            db.Open();
            var sql = @"INSERT INTO ""Test"".""BUY"" (""DATE"", ""IDORDER"")
                        VALUES  (@Date, @OrderId)
                        ";
            var result = await db.ExecuteAsync(sql, new { Date = date, OrderId = orderId });
            db.Close();
            ItemBuyDbModel modelBuyItem;
            foreach (var item in model.ItemIdList.Distinct())
            {
                modelBuyItem = new ItemBuyDbModel
                {
                    IdBuy = getLastIdBuy(),
                    IdItem = item,
                    Quantity = getQuantity(model.ItemIdList, item)
                };
                await RecordBuyItem(modelBuyItem);
            }

            return result > 0;
        }

        /// <summary>
        /// This method insets record in BUYITEM table
        /// </summary>
        /// <param name="model">buyOrder model to be te insert</param>
        /// <returns>
        /// True if the record inserted succesfull,
        /// Flase if the record inserted unsuccesfull
        /// </returns>
        public async Task<bool> RecordBuyItem(ItemBuyDbModel model)
        {
            var idItem = model.IdItem;
            var idBuy = model.IdBuy;
            var quantity = model.Quantity;
            var db = _connection.makeConnection();
            db.Open();
            var sql = @"INSERT INTO ""Test"".""BUYITEM"" (""IDBUY"", ""IDITEM"", ""QUANTITY"")
                        VALUES  (@IdBuy, @IdItem, @Quantity)
                        ";
            var result = await db.ExecuteAsync(sql, new { IdBuy = idBuy, IdItem = idItem,
                                                        Quantity = quantity });
            db.Close();
            return result > 0;
        }

        /// <summary>
        /// This method gets the quantity a item is on an buy
        /// </summary>
        /// <param name="list">items list that have a buy</param>
        /// <param name="id">id item to be the search</param>
        /// <returns>quantity that an item is in the buy</returns>
        public int getQuantity(List<int> list, int id)
        {
            int numberRepetitions = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (id == list[i])
                {
                    numberRepetitions++;
                }
            }
            return numberRepetitions;
        }

        /// <summary>
        /// This method looks the id that have a last buy.
        /// </summary>
        /// <returns>id that have a last buy</returns>
        public int getLastIdBuy()
        {
            var db = _connection.makeConnection();
            db.Open();
            var sql = @"SELECT MAX(""Id"") 
                        FROM ""Test"".""BUY"" ";

            int max = db.ExecuteScalar<int>(sql);
            db.Close();
            return max;
        }
    }
}
