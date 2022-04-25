using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.TestDataBase
{
    /// <summary>
    /// 
    /// </summary>
    public class Connection
    {
        private NpgsqlConnection _conn;
        private string server, dataBase, user, password, port, conectionString;

        
        public Connection()
        {
            _conn = new NpgsqlConnection();
            server = "localhost";
            dataBase = "Test";
            port = "5432";
            password = "20deseptiembre";
            user = "postgres";
            conectionString = "server=" + server + ";" + "port=" + port + ";" + "user id=" + user + ";password=" + password + ";database=" + dataBase + ";";
        }

        /// <summary>
        /// This method make the conection to the postgreSQL data base
        /// </summary>
        /// <returns>Objet NpgsqlConnection</returns>
        public NpgsqlConnection makeConnection()
        {
            try
            {
                _conn.ConnectionString = conectionString;
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine("error conection -> "+ e);
            }
            return _conn;
        }
    }
}
