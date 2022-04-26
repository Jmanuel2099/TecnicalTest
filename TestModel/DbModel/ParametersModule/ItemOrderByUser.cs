using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.DbModel.ParametersModule
{
    public class ItemOrderByUser
    {
        private int _idOrder;
        private int _idItem;
        private string ? _name;
        private string ? _description;
        private string ? _image;
        private int ? _quantity;

        public int IdOrder { get => _idOrder; set => _idOrder = value; }
        public int IdItem { get => _idItem; set => _idItem = value; }
        public string? Name { get => _name; set => _name = value; }
        public string? Description { get => _description; set => _description = value; }
        public string? Image { get => _image; set => _image = value; }
        public int? Quantity { get => _quantity; set => _quantity = value; }
    }
}
