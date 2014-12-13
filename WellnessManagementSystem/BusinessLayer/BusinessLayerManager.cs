using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BusinessLayer.Entities;
using DatabaseEntities;
using System.Collections;

namespace BusinessLayer
{
    public class BusinessLayerManager
    {
        public static Hashtable reportTypeStrings =new Hashtable(){{(int)ReportType.LabReport,ReportTypeResource.LabReport},
                                                                   {(int)ReportType.DietPlan,ReportTypeResource.DietPlan},
                                                                   {(int)ReportType.PhysicalCondition,ReportTypeResource.PhysicalCondition}};
        public List<BOLabReport> GetLabReportsForClient(int clientID,int userID)
        {
            try
            {
                DataLayerManager dataLayer = new DataLayerManager();
                List<LabReport> reports = dataLayer.GetLabReportsForClient(clientID, userID);
                List<BOLabReport> labReports = (from report in reports
                                                select new BOLabReport
                                                {
                                                    LabReportID = report.LabReportID,
                                                    ReportFieldName = report.ReportFieldMaster.ReportFieldName,
                                                    ReportFieldValue = report.ReportFieldValue,
                                                    ReportFieldID = report.ReportFieldID,
                                                    TestDate = report.TestDate,
                                                    Remark1 = report.Remark1,
                                                    Remark2 = report.Remark2
                                                }).ToList();
                return labReports;
            }
            catch (Exception exception)
            {
                throw (exception);
            }
        }
        public Dictionary<string, List<BOUserField>> GetReportFieldsForUser(int userID)
        {
            DataLayerManager dataLayer = new DataLayerManager();

            List<UserReportField> listOfReportFieldsForUser = dataLayer.GetUserFields(userID);
            Dictionary<string, List<BOUserField>> userFieldsDictionary = new Dictionary<string,List<BOUserField>>();
            for (int reportType = (int)ReportType.LabReport; reportType < (int)ReportType.PhysicalCondition; reportType++)
            {
                List<BOUserField> userReportFields = GetUserFieldNamesForReportType(listOfReportFieldsForUser, (int)ReportType.LabReport);
                userFieldsDictionary.Add(BusinessLayerManager.reportTypeStrings[reportType].ToString(), userReportFields);
            }
            
            return userFieldsDictionary;
        }

        private static List<BOUserField> GetUserFieldNamesForReportType(List<UserReportField> listOfUserReportFields,int reportType)
        {
            List<BOUserField> listOfReportFieldsForReportType = (from reportField in listOfUserReportFields
                                                                 where reportField.ReportFieldMaster.ReportTypeID==reportType
                                                 select new BOUserField
                                                 {
                                                    ReportFieldID = reportField.ReportFieldID,
                                                    ReportFieldName = reportField.ReportFieldMaster.ReportFieldName
                                                 }).ToList();
            return listOfReportFieldsForReportType;
        }
        public BOUser GetUser(string userName, string password)
        {
            try
            {
            DataLayerManager datalayer = new DataLayerManager();
            User user = datalayer.GetUser(userName, password);

            if (user != null)
            {
                BOUser appUser = new BOUser();
                appUser.UserID = user.UserId;
                appUser.UserName = user.UserName;
                appUser.OccupationID = user.OccupationID;
                return appUser;
            }
            else
            {
                return null;
            }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
    }
}
}
