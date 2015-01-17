using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class BODietPlan
    {
       public int DietPlanReportID { get; set; }
       public DateTime TestDate { get; set; }
       public string BMI { get; set; }
       public string Morning { get; set; }
       public string Afternoon { get; set; }
       public string Evening { get; set; }
       public string Night { get; set; }
    }
}
