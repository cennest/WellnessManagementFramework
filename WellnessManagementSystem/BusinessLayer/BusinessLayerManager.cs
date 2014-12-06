using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BusinessLayer.Entities;


namespace BusinessLayer
{
    public class BusinessLayerManager
    {
        public List<ClientSummary> GetAllClientsSummary()
        {
            ClientSummary client1 = new ClientSummary();
            client1.ClientID = 1;
            client1.ClientName = "Annu Raj";
            client1.ClientNotificationID = "No Notification";
            client1.ClientLastNotes = "No Notes";

            ClientSummary client2 = new ClientSummary();
            client2.ClientID = 2;
            client2.ClientName = "Gagan Narang";
            client2.ClientNotificationID = "No Notification";
            client2.ClientLastNotes = "No Notes";

            ClientSummary client3 = new ClientSummary();
            client3.ClientID = 3;
            client3.ClientName = "Marry Kom";
            client3.ClientNotificationID = "No Notification";
            client3.ClientLastNotes = "No Notes";

            ClientSummary client4 = new ClientSummary();
            client4.ClientID = 4;
            client4.ClientName = "Pooja gatkar";
            client4.ClientNotificationID = "No Notification";
            client4.ClientLastNotes = "No Notes";

            ClientSummary client5 = new ClientSummary();
            client5.ClientID = 5;
            client5.ClientName = "Shiv Thapa";
            client5.ClientNotificationID = "No Notification";
            client5.ClientLastNotes = "No Notes";

            ClientSummary client6 = new ClientSummary();
            client6.ClientID = 6;
            client6.ClientName = "Shweta Choudhary";

            List<ClientSummary> allClientSummary = new List<ClientSummary>();
            allClientSummary.Add(client1);
            allClientSummary.Add(client2);
            allClientSummary.Add(client3);
            allClientSummary.Add(client4);
            allClientSummary.Add(client5);
            allClientSummary.Add(client6);

            return allClientSummary;
        }



    }
}
