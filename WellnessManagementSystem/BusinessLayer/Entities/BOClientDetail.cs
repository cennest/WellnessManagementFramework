using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    class BOClientDetail
    {
      public int ClientID { get; set; }
      public BOClient Client { get; set; }
      public BODietPlan DietPlan { get; set; }
      public BOLabReport LabReport { get; set; }
      public BOPhysicalConditionReport PhysicalCondition { get; set; }
    }
}
