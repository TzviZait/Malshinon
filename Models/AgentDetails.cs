using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Malshinon.DAL;

namespace Malshinon.Models
{
    public class AgentDetails
    {
        public int IdAgent { get; set; }
        public string FullName { get; set; }
        public string CodeName { get; set; }

    }
}
