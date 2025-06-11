using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Models
{
    public class AgentReport
    {
        public int IdMessage{get; set;}

        public int IdAgent {get; set;}

        public int TerroristName {get; set;}

        public DateTime TimeStamp { get; set;}

        public string Message { get; set;}

        public bool MessageIsAnalyzed { get; set;}
    }
}
