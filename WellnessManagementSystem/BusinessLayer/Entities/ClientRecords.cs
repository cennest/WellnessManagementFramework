using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BusinessLayer.Entities
{
    class ClientRecords
    {
        public ReportType ReportType { get; set; }
        public int ClientID { get; set; }
        public DateTime TestDate;
        public Hashtable TestValues{get; set;}
 
    }
}
