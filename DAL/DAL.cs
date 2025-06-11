using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Malshinon.DAL
{
    public static class Dal
    {
        private static string connectionString = 
            "server=localhost;" +
            "user=root;" +
            "database=malshinon;" +
            "port=3306;";
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

    }
}