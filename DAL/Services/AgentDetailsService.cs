using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.Models;
using MySql.Data.MySqlClient;

namespace Malshinon.DAL.agent
{
    public static class AgentDetailsService
    {

        public static bool AgentIsExsist(int id)
        {
            MySqlConnection connection = Dal.GetConnection();
            string query = "SELECT * FROM agentdetails WHERE idAgent = @Id";
            MySqlCommand command = new MySqlCommand(query, connection);

            connection.Open();
            command.Parameters.AddWithValue("@Id", id);
            MySqlDataReader reader = command.ExecuteReader();
            bool exsist = reader.HasRows;
            connection.Close();
            return exsist;

        }

        public static void AddAgent(int idAgent , string fullName , string codeName)
        {
            MySqlConnection connection = Dal.GetConnection();

            string query = "INSERT INTO agentdetails(idAgent,fullName,codeName)" +
                           "VALUES(@IdAgent,@FullName,@CodeName)";

            MySqlCommand command = new MySqlCommand( query, connection);

            connection.Open();

            command.Parameters.AddWithValue("@IdAgent" , idAgent);

            command.Parameters.AddWithValue("@FullName", fullName);

            command.Parameters.AddWithValue("@CodeName", codeName);

            command.ExecuteNonQuery();

        }
    }
}
