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

            ClientSummary client2 = new ClientSummary();
            client2.ClientID = 2;
            client2.ClientName = "Gagan Narang";

            ClientSummary client3 = new ClientSummary();
            client3.ClientID = 3;
            client3.ClientName = "Marry Kom";

            ClientSummary client4 = new ClientSummary();
            client4.ClientID = 4;
            client4.ClientName = "Pooja gatkar";

            ClientSummary client5 = new ClientSummary();
            client5.ClientID = 5;
            client5.ClientName = "Shiv Thapa";

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
