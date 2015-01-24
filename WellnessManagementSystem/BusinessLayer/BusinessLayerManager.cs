using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BusinessLayer.Entities;
using DatabaseEntities;
using System.Collections;
using System.Collections.ObjectModel;
using System.Dynamic;

namespace BusinessLayer
{
    public class BusinessLayerManager
    {
        public static Hashtable reportTypeStrings = new Hashtable(){{(int)ReportType.LabReport,ReportTypeResource.LabReport},
                                                                   {(int)ReportType.DietPlan,ReportTypeResource.DietPlan},
                                                                   {(int)ReportType.PhysicalCondition,ReportTypeResource.PhysicalCondition}};
        public List<BOLabReport> GetLabReportsForClient(int clientID, int userID)
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
            Dictionary<string, List<BOUserField>> userFieldsDictionary = new Dictionary<string, List<BOUserField>>();
            for (int reportType = (int)ReportType.LabReport; reportType < (int)ReportType.PhysicalCondition; reportType++)
            {
                List<BOUserField> userReportFields = GetUserFieldNamesForReportType(listOfReportFieldsForUser, (int)ReportType.LabReport);
                userFieldsDictionary.Add(BusinessLayerManager.reportTypeStrings[reportType].ToString(), userReportFields);
            }

            return userFieldsDictionary;
        }

        private static List<BOUserField> GetUserFieldNamesForReportType(List<UserReportField> listOfUserReportFields, int reportType)
        {
            List<BOUserField> listOfReportFieldsForReportType = (from reportField in listOfUserReportFields
                                                                 where reportField.ReportFieldMaster.ReportTypeID == reportType
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

        public List<BOCategory> GetAllCategories()
        {
            try
            {
                DataLayerManager datalayer = new DataLayerManager();
                List<CategoryMaster> listOfCategories = datalayer.GetAllCategories();
                List<BOCategory> Categories = new List<BOCategory>();
                if (listOfCategories.Count > 0)
                {
                    foreach (CategoryMaster category in listOfCategories)
                    {
                        BOCategory categoryObject = new BOCategory();
                        categoryObject.CategoryID = category.CategoryID;
                        categoryObject.CategoryName = category.CategoryName;
                        Categories.Add(categoryObject);
                    }
                }
                return Categories;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<BOClient> GetClientsForCategories(int categoryID, int userID, int skip, int take)
        {
            try
            {
                DataLayerManager datalayer = new DataLayerManager();
                List<Client> listOfClients = datalayer.GetClientsForCategories(categoryID, userID, skip, take);
                List<BOClient> clients = GetClientBOForClientDBObjects(listOfClients);
                return clients;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<BOClient> GetClientsForCategories(int categoryID, int userID)
        {
            try
            {
                DataLayerManager datalayer = new DataLayerManager();
                List<Client> listOfClients = datalayer.GetClientsForCategories(categoryID, userID);
                List<BOClient> clients = GetClientBOForClientDBObjects(listOfClients);
                return clients;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public int GetCountOfClientsForCategories(int categoryID, int userID)
        {
            try
            {
                DataLayerManager datalayer = new DataLayerManager();
                int countOfClients = datalayer.GetCountOfClientsForCategories(categoryID, userID);
                return countOfClients;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<BOClient> GetClientsForCategoryByName(int categoryID, string searchString, int userID, int skip, int take)
        {
            try
            {
                DataLayerManager datalayer = new DataLayerManager();
                List<Client> listOfClients = datalayer.GetClientsForCategoryByName(categoryID, searchString, userID, skip, take);
                List<BOClient> clients = GetClientBOForClientDBObjects(listOfClients);
                return clients;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public int GetCountOfClientsForCategoryByName(int categoryID, string searchString, int userID)
        {
            try
            {
                DataLayerManager datalayer = new DataLayerManager();
                int countOfClients = datalayer.GetCountOfClientsForCategoryByName(categoryID, searchString, userID);
                return countOfClients;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        private List<BOClient> GetClientBOForClientDBObjects(List<Client> clients)
        {
            List<BOClient> listOfClients = new List<BOClient>();
            if (clients.Count > 0)
            {
                foreach (Client client in clients)
                {
                    BOClient clientObject = new BOClient();
                    clientObject.ClientID = client.ClientID;
                    clientObject.ClientName = client.ClientName;
                    clientObject.ClientNotes = "No Notes";
                    clientObject.ClientNotification = "No New Notification";
                    listOfClients.Add(clientObject);
                }
            }
            return listOfClients;
        }

        public bool SaveEditedReportsForClient(int clientID, ObservableCollection<ExpandoObject> editedLabResults, int userID)
        {
            List<LabReport> labReports = new List<LabReport>();
            //Convert this Expando list to a List of BOLapReport
            foreach (ExpandoObject expando in editedLabResults)
            {
                var report = expando as IDictionary<String, object>;
                foreach (string k in report.Keys)
                {
                    int negative = -1;
                    if (int.TryParse(k, out negative))
                    {
                        LabReport labReport = new LabReport();
                        labReport.TestDate = DateTime.Parse((string)report["TestDate"]);
                        labReport.ReportFieldID = int.Parse(k);
                        labReport.ReportFieldValue = (string)report[k];
                        labReports.Add(labReport);
                    }
                }

            }
            DataLayer.DataLayerManager dataLayerObject = new DataLayer.DataLayerManager();
            dataLayerObject.SaveLabReportsForClient(labReports, clientID, userID);
            return true;
        }

        public bool SavePhysicalConditionReportsForClient(List<int> deletedPhysicalConditionRecordIds, List<BOPhysicalConditionReport> physicalConditionReportList, int clientID, int userID)
        {
            try
            {
                List<PhysicalConditionReport> physicalConditionList = new List<PhysicalConditionReport>();
                foreach (BOPhysicalConditionReport physicalConditionReport in physicalConditionReportList)
                {
                    PhysicalConditionReport physicalCondition = new PhysicalConditionReport();
                    physicalCondition.PhysicalConditionReportID = physicalConditionReport.PhysicalConditionID;
                    physicalCondition.TestDate = physicalConditionReport.TestDate;
                    physicalCondition.MSKAssessmentImpressions = physicalConditionReport.MSKAssessment;
                    physicalCondition.Advice = physicalConditionReport.Advice;
                    physicalConditionList.Add(physicalCondition);
                }
                DataLayer.DataLayerManager dataLayerObject = new DataLayer.DataLayerManager();
                dataLayerObject.SavePhysicalConditionReportsForClient(deletedPhysicalConditionRecordIds, physicalConditionList, clientID, userID);
                return true;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public int GetPhysicalConditioningReportsCount(int userID, int clientID, DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                DataLayerManager dataLayer = new DataLayerManager();
                int physicalConditioningReportCount = dataLayer.GetPhysicalConditioningReportsCount(userID, clientID, fromDate, toDate);
                return physicalConditioningReportCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<BOPhysicalConditionReport> GetPhysicalConditioningReportsWithinDates(int userID, int clientID, int skip, int take, DateTime? fromDate, DateTime? toDate)
        {
            try
            {

                DataLayerManager dataLayer = new DataLayerManager();
                List<PhysicalConditionReport> listOfPhysicalConditionReports = dataLayer.GetPhysicalConditioningReportsWithinDates(userID, clientID, skip, take, fromDate, toDate);
                List<BOPhysicalConditionReport> physicalConditioningReports = GetPhysicalConditioningReportBOForPhysicalConditioningReportDBObjects(listOfPhysicalConditionReports);
                return physicalConditioningReports;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<BOPhysicalConditionReport> GetPhysicalConditioningReportsForCategoryByName(int userID, int clientID, int categoryID, string searchString, DateTime? fromDate, DateTime? toDate, int skip, int take)
        {
            try
            {
                DataLayerManager dataLayer = new DataLayerManager();
                List<PhysicalConditionReport> listOfPhysicalConditioningReports = dataLayer.GetPhysicalConditioningReportsForCategoryByName(userID, clientID, categoryID, searchString, fromDate, toDate, skip, take);
                List<BOPhysicalConditionReport> physicalConditioningReports = GetPhysicalConditioningReportBOForPhysicalConditioningReportDBObjects(listOfPhysicalConditioningReports);
                return physicalConditioningReports;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private List<BOPhysicalConditionReport> GetPhysicalConditioningReportBOForPhysicalConditioningReportDBObjects(List<PhysicalConditionReport> physicalConditioningReports)
        {
            List<BOPhysicalConditionReport> listOfPhysicalConditioningReports = new List<BOPhysicalConditionReport>();
            if (physicalConditioningReports.Count > 0)
            {
                foreach (PhysicalConditionReport PhysicalConditioningReport in physicalConditioningReports)
                {
                    BOPhysicalConditionReport physicalConditioningReportObject = new BOPhysicalConditionReport();
                    physicalConditioningReportObject.PhysicalConditionID = PhysicalConditioningReport.PhysicalConditionReportID;
                    physicalConditioningReportObject.TestDate = PhysicalConditioningReport.TestDate;
                    physicalConditioningReportObject.MSKAssessment = PhysicalConditioningReport.MSKAssessmentImpressions;
                    physicalConditioningReportObject.Advice = PhysicalConditioningReport.Advice;
                    listOfPhysicalConditioningReports.Add(physicalConditioningReportObject);
                }
            }
            return listOfPhysicalConditioningReports;
        }

        public List<BOLabReport> GetLabReportsForClientID(int clientID, int userID, int reportID)
        {
            try
            {
                DataLayerManager dataLayer = new DataLayerManager();
                List<LabReport> reports = dataLayer.GetLabReportsForClientID(clientID, userID, reportID);
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

        public Hashtable GetLabReportsForCategory(int categoryID, int userID, int reportID)
        {
            try
            {
                DataLayerManager dataLayer = new DataLayerManager();
                List<int> clientList = dataLayer.GetClientsForCategoryID(categoryID, userID);
                Hashtable listOfReportForCategoryHasTable = new Hashtable();
                if (clientList.Count > 0)
                {
                    foreach (int clientID in clientList)
                    {
                        List<BOLabReport> labReports = this.GetLabReportsForClientID(clientID, userID, reportID);
                        listOfReportForCategoryHasTable.Remove(clientID);
                        listOfReportForCategoryHasTable.Add(clientID, labReports);
                    }
                }
                return listOfReportForCategoryHasTable;
            }
            catch (Exception exception)
            {
                throw (exception);
            }
        }

        public List<BOReporting> GetAllReports()
        {
            try
            {
                DataLayerManager datalayer = new DataLayerManager();
                List<ReportFieldMaster> listOfReports = datalayer.GetAllTests();
                List<BOReporting> reports = new List<BOReporting>();
                if (listOfReports.Count > 0)
                {
                    foreach (ReportFieldMaster report in listOfReports)
                    {
                        BOReporting reportObject = new BOReporting();
                        reportObject.ReportFieldID = report.ReportFieldID;
                        reportObject.ReportFieldName = report.ReportFieldName;
                        reportObject.ReportTypeID = report.ReportTypeID;
                        reports.Add(reportObject);
                    }
                }
                return reports;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}