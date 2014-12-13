using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    class BOClientSummary
    {
        public int ClientID {get; set;}
        public BOLabReport LabReport { get; set; }
    }
}
