using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Malshinon.DAL.Services
{
    internal class Test
    {
        public static int ExecuteRead(string sql, Dictionary<string, object> parameters = null)
        {
            MySqlConnection connection = Dal.GetConnection();

            connection.Open();

            MySqlCommand command = new MySqlCommand(sql, connection);

            foreach (var param in parameters)
            {
                command.Parameters.AddWithValue(param.Key, param.Value);
            }

            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader.GetInt32(0);
        }

    }
}
