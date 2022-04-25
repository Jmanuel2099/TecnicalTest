using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.DbModel.ParametersModule
{
    /// <summary>
    /// Order model
    /// </summary>
    public class OrderDbModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }


        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private List<int> itemIdList;

        public List<int> ItemIdList
        {
            get { return itemIdList; }
            set { itemIdList = value; }
        }

    }
}
