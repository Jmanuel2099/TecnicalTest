using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.DbModel.ParametersModule
{
    /// <summary>
    /// items that have a buy.
    /// </summary>
    public class ItemBuyDbModel
    {
        private int idBuy;

        public int IdBuy
        {
            get { return idBuy; }
            set { idBuy = value; }
        }

        private int idItem;

        public int IdItem
        {
            get { return idItem; }
            set { idItem = value; }
        }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }
}
