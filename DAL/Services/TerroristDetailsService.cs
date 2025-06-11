using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.Models;
using MySql.Data.MySqlClient;

namespace Malshinon.DAL.Services
{
    public class TerroristDetailsService
    {
        public static bool IsExsist(string fullName)
        {
            MySqlConnection connection = Dal.GetConnection();
            string query = "SELECT * FROM terroristdetails WHERE fullName = @FullName";
            MySqlCommand command = new MySqlCommand(query, connection);

            connection.Open();
            command.Parameters.AddWithValue("@FullName", fullName);
            MySqlDataReader reader = command.ExecuteReader();
            bool exsist = reader.HasRows;
            connection.Close();
            return exsist;

        }

        public static void AddTerrorist(string fullName)
        {
            MySqlConnection connection = Dal.GetConnection();

            string query = "INSERT INTO terroristdetails(fullName)" +
                           "VALUES(@FullName)";

            MySqlCommand command = new MySqlCommand(query, connection);

            connection.Open();

            command.Parameters.AddWithValue("@FullName",fullName);

            command.ExecuteNonQuery();

        }
    }
}

