using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    class BODietPlan
    {
       public int DietPlanID { get; set; }
       public DateTime TestDate { get; set; }
       public string BMI { get; set; }
       public string EarlyMorning { get; set; }
       public string BreakFast { get; set; }
       public string MidMorning { get; set; }
       public string Lunch { get; set; }
       public string Tea { get; set; }
       public string Evening { get; set; }
       public string Dinner { get; set; }
       public string Suggestions { get; set; }
    }
}
