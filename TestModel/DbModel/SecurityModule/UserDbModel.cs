using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.DbModel.SecurityModule
{
    /// <summary>
    /// User model
    /// </summary>
    public class UserDbModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string secondName;

        public string SecondName
        {
            get { return secondName; }
            set { secondName = value; }
        }

        private string firstLastName;

        public string FirstLastName
        {
            get { return firstLastName; }
            set { firstLastName = value; }
        }

        private string seconLastdName;

        public string SecondLastName
        {
            get { return seconLastdName; }
            set { seconLastdName = value; }
        }

        private bool remove;

        public bool Remove
        {
            get { return remove; }
            set { remove = value; }
        }
    }
}
