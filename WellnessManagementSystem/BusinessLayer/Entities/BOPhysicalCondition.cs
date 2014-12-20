using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    class BOPhysicalCondition
    {
       public int PhysicalConditionID { get; set; }
       public DateTime TestDate { get; set; }
       public string MSKAssessment { get; set; }
       public string Advice { get; set; }
    }
}
