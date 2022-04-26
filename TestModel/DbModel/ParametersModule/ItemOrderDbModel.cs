using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.DbModel.ParametersModule
{
    /// <summary>
    /// items that have a order
    /// </summary>
    public class ItemOrderDbModel
    {
        private int idOrder;
        private int idItem;
        private int quantity;

        public int IdOrder { get => idOrder; set => idOrder = value; }
        public int IdItem { get => idItem; set => idItem = value; }
        public int Quantity { get => quantity; set => quantity = value; }

    }
}
