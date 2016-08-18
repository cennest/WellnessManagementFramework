using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public enum Category
    {
        AllSports = 0,
        Shooter,
        WeightLifter,
        Archer,
        Swimmer,
        Boxer,
        Sprinter,
        Squash
    }

    public enum ReportType
    {
        LabReport = 1,
        DietPlanReport,
        PhysicalConditionReport
    }
}
