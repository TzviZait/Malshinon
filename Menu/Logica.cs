using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.DAL.Services;
using Malshinon.DAL.agent;
using Malshinon.Models;
using Org.BouncyCastle.Crypto;



namespace Malshinon.Menu
{
    internal class Logica
    {
        public static void AddAgentDetails(int idAgent, string fullName, string codeName)
        {
            if (!AgentDetailsService.AgentIsExsist(idAgent))
            {
                AgentDetailsService.AddAgent( idAgent,  fullName,  codeName);
            }
        }
        public static void AnalyzeReports()
        {
            List<AgentReport> agentReports = AgentReportService.ReadReportIsNotAnalyzer();
            foreach (var agentReport in agentReports)
            {
                int idAgent = agentReport.IdAgent;
                int lengthMessage = agentReport.Message.Length;
                int idMessage = agentReport.IdMessage;
                AgentReportService.UpdeteAgentReportAnalyzer(idAgent, lengthMessage);
                AgentReportService.UpdeteMessageIsAnalyzed(idMessage);

            }
        }

        public static void AddTerroristDetails(string fullName)
        {
            if(!TerroristDetailsService.IsExsist(fullName))
            {
                TerroristDetailsService.AddTerrorist(fullName);
            }
        }

    }
}
