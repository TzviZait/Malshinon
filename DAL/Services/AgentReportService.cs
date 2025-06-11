using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.Models;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;

namespace Malshinon.DAL.Services
{
    public class AgentReportService
    {
        public static void AddReports(int agentId, int terroristName, string message) 
        {
            MySqlConnection connection = Dal.GetConnection();
            
            string query = "INSERT INTO agentreport(idAgent ,terroristName ,message)" +
                           "VALUES(@IdAgent,@TerroristName,@Message)";

            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();

            command.Parameters.AddWithValue("@IdAgent", agentId);

            command.Parameters.AddWithValue("@TerroristName", terroristName);

            command.Parameters.AddWithValue("@Message", message);

            command.ExecuteNonQuery();

        }

        public static List<AgentReport> ReadReportIsNotAnalyzer()
        {
            MySqlConnection connection = Dal.GetConnection();

            string query = "SELECT * FROM agentreport WHERE messageIsAnalyzed = false";

            MySqlCommand command = new MySqlCommand(query, connection);

            connection.Open();

            MySqlDataReader reader = command.ExecuteReader();
            List<AgentReport>  agentReports = new List<AgentReport>();
            // List<AgentReportAnalyzer> agentReports = new List<AgentReportAnalyzer>();
            while (reader.Read())
            {
                AgentReport agentReport = new AgentReport
                {
                    IdMessage = reader.GetInt32("idMessage"),
                    IdAgent = reader.GetInt32("idAgent"),
                    TerroristName = reader.GetInt32("terroristName"),
                    TimeStamp = reader.GetDateTime("timeStamp"),
                    Message = reader.GetString("message"),
                    MessageIsAnalyzed = reader.GetBoolean("messageIsAnalyzed")
                };
                //AgentReportAnalyzer agentReportAnalyzer = new AgentReportAnalyzer
                //{
                //    IdAgent = reader.GetInt32("idAgent"),
                //    LengthMessage = reader.GetString("message").Length,
                //    CountMessage = 1
                //};

                agentReports.Add(agentReport);
            }

            reader.Close();
            connection.Close();
            return agentReports;
        }


        public static void UpdeteAgentReportAnalyzer(int id, int len)
        {
            MySqlConnection connection = Dal.GetConnection();
            string query = """
                           INSERT INTO AgentReportAnalyzer (idAgent, lengthMessage, countMessage) 
                           VALUES (@idAgent, @lengthMessage, 1)
                           ON DUPLICATE KEY UPDATE 
                               lengthMessage = lengthMessage + @lengthMessage, 
                               countMessage = countMessage + 1;
                           """;
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.Parameters.AddWithValue("@idAgent", id);
            command.Parameters.AddWithValue("@lengthMessage", len);
            command.ExecuteNonQuery();
            connection.Close();
        }


        public static void UpdeteMessageIsAnalyzed(int id) 
        {
            MySqlConnection connection = Dal.GetConnection();
            string query = "UPDATE agentreport SET messageIsAnalyzed = true WHERE id = @idMessage";
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            command.Parameters.AddWithValue("@idMessage", id);
            command.ExecuteNonQuery();
            connection.Close();

        }
    }
    
}
