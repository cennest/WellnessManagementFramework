using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
   public class BOLabReport
    {
        public int LabReportID { get; set; }
        public DateTime TestDate { get; set; }
        public int ReportFieldID { get; set; }
        public string ReportFieldName { get; set; }
        public string ReportFieldValue { get; set; }
        public string Remark1 { get; set; }
        public string Remark2 { get; set; }
    }
}
