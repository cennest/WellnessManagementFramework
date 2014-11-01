using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    class LabReport
    {
     public int LabReportID{ get; set; }
     public DateTime TestDate { get; set; }
     public string VitaminB12 { get; set; }
     public string VitaminD { get; set; }
     public string VitaminDLow { get; set; }
     public string VitaminDHigh { get; set; }
     public string Calcium { get; set; }
     public string HB { get; set; }
     public string BGRP { get; set; }
     public string RBC { get; set; }
     public string Hemato { get; set; }
     public string WBC { get; set; }
     public string Platelet { get; set; }
     public string Thyroid { get; set; }
     public string Remark1 { get; set; }
     public string Remark2 { get; set; }
     public DateTime NextTestDate { get; set; }
    }
}
