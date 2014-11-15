using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string UserAddress { get; set; }
        public int OccupationID { get; set; }
    }
}
