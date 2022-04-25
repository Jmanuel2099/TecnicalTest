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

        public int IdOrder
        {
            get { return idOrder; }
            set { idOrder = value; }
        }

        private int idItem;

        public int IdItem
        {
            get { return idOrder; }
            set { idOrder = value; }
        }

        private int quantity;

        public int Quantity
        {
            get { return idOrder; }
            set { idOrder = value; }
        }
    }
}
