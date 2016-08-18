using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
   public class BOClient
    {
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string ClientNotes { get; set; }
        public string ClientNotification { get; set; }
        public TestDateStatus TestDateStatus { get; set; }

    }
}
