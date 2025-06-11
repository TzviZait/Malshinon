using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Models
{
    public class TerroristAnalyze
    {
        //id terroristId reportId reportTime
        public int Id { get; set; }

        public int TerroristId { get; set; }

        public int ReportId { get; set; }

        public DateTime ReportTime { get; set; }


    }
}
