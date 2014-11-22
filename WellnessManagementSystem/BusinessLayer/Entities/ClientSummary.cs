using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class ClientSummary
    {
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string ClientNotificationID { get; set; }
        public string ClientLastNotes { get; set; }
    }
}
