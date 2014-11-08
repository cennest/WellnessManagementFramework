using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    class ClientDetail
    {
      public int ClientID { get; set; }
      public Client Client { get; set; }
      public DietPlan DietPlan { get; set; }
      public LabReport LabReport { get; set; }
      public PhysicalCondition PhysicalCondition { get; set; }
    }
}
