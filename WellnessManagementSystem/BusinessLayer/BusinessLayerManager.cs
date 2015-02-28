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
    public partial class BusinessLayerManager
    {
        //Notification string
        const string UPCOMMING_TEST = "Upcoming test date on ";
        const string ELAPSED_TEST = "Date elapsed for test on ";
        const string NO_NOTIFICATION = "No New Notification";
        const string NOTIFICATION_DATE_FORMATE = "dd MMMM, yyyy";
        const int TEST_INTERVAL = 3; // values in Months
        const int NOTIFICATION_TIME = 30; // Values in Days

        
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
                List<Client> listOfClients = datalayer.GetClientsForCategoryByName(categoryID,searchString, userID, skip, take);
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
            DataLayerManager datalayer = new DataLayerManager();
            List<BOClient> listOfClients = new List<BOClient>();
            if (clients.Count > 0)
            {
                foreach (Client client in clients)
                {
                    BOClient clientObject = new BOClient();
                    clientObject.ClientID = client.ClientID;
                    clientObject.ClientName = client.ClientName;
                    clientObject.ClientNotes = datalayer.GetNoteForClient(client.ClientID);
                    clientObject.ClientNotification = GetLastLabReportDateForClient(client.ClientID);
                    listOfClients.Add(clientObject);
                }
            }
            return listOfClients;
        }

        //public string GetNoteOverviewForClient(int clientID)
        //{
        //    //System.Windows.Forms.RichTextBox rtBox = new System.Windows.Forms.RichTextBox();


        //    //string note = datalayer.GetNoteForClient(client.ClientID);
        //    //var document = noteEditor.Document;
        //    //var range = new TextRange(document.ContentStart, document.ContentEnd);
        //    //var ms = new MemoryStream();
        //    //var writer = new StreamWriter(ms);
        //    //writer.Write(note);
        //    //writer.Flush();
        //    //ms.Seek(0, SeekOrigin.Begin);
        //    //range.Load(ms, DataFormats.Rtf);
        //}
        public string GetLastLabReportDateForClient(int clientID)
        {
            try
            {
                string notification = null;
                DataLayerManager datalayer = new DataLayerManager();
                DateTime? lastLabReportDate = datalayer.GetLastLabReportDateForClient(clientID);
                if (lastLabReportDate == null)
                {
                    return notification = NO_NOTIFICATION;
                }
                DateTime nextLabReportDate = lastLabReportDate.Value.AddMonths(TEST_INTERVAL);
                TimeSpan timeSpan = nextLabReportDate.Subtract(DateTime.Now);
                if (timeSpan.Days > NOTIFICATION_TIME)
                {
                    notification = NO_NOTIFICATION;
                }
                else
                {
                    if (nextLabReportDate > DateTime.Now)
                    {
                        notification = UPCOMMING_TEST + nextLabReportDate.ToString(NOTIFICATION_DATE_FORMATE);
                    }
                    else if (nextLabReportDate < DateTime.Now)
                    {

                        notification = ELAPSED_TEST + nextLabReportDate.ToString(NOTIFICATION_DATE_FORMATE);
                    }
                }
                return notification;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
            dataLayerObject.SaveLabReportsForClient(labReports, clientID,userID);
            return true;
        }

        public bool SavePhysicalConditionReportsForClient(List<int> deletedPhysicalConditionRecordIds,List<BOPhysicalConditionReport> physicalConditionReportList, int clientID, int userID)
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
                dataLayerObject.SavePhysicalConditionReportsForClient(deletedPhysicalConditionRecordIds,physicalConditionList, clientID, userID);
                return true;
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public int GetPhysicalConditioningReportsCount(int userID,int clientID,DateTime? fromDate,DateTime? toDate)
        {
            try
            {
                DataLayerManager dataLayer = new DataLayerManager();
                int physicalConditioningReportCount = dataLayer.GetPhysicalConditioningReportsCount(userID, clientID, fromDate,toDate);
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

        public bool SaveDietPlanReportsForClient(List<int> deleteDietPlanRecordIds, List<BODietPlan> dietPlanReportList, int clientID, int userID)
        {
            try
            {
                List<DietPlanReport> dietPlanList = new List<DietPlanReport>();
                foreach (BODietPlan dietPlanReport in dietPlanReportList)
                {
                    DietPlanReport dietPlan = new DietPlanReport();
                    dietPlan.DietPlanReportID = dietPlanReport.DietPlanReportID;
                    dietPlan.TestDate = dietPlanReport.TestDate;
                    dietPlan.BMI = dietPlanReport.BMI;
                    dietPlan.Morning = dietPlanReport.Morning;
                    dietPlan.Afternoon = dietPlanReport.Afternoon;
                    dietPlan.Evening = dietPlanReport.Evening;
                    dietPlan.Night = dietPlanReport.Night;
                    dietPlanList.Add(dietPlan);
                }
                DataLayer.DataLayerManager dataLayerObject = new DataLayer.DataLayerManager();
                dataLayerObject.SaveDietPlanReportsForClient(deleteDietPlanRecordIds, dietPlanList, clientID, userID);
                return true;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public int GetDietPlanReportsCount(int userID, int clientID, DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                DataLayerManager dataLayer = new DataLayerManager();
                int dietPlanReportCount = dataLayer.GetDietPlanReportsCount(userID, clientID, fromDate, toDate);
                return dietPlanReportCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<BODietPlan> GetDietPlanReportsWithinDates(int userID, int clientID, int skip, int take, DateTime? fromDate, DateTime? toDate)
        {
            try
            {

                DataLayerManager dataLayer = new DataLayerManager();
                List<DietPlanReport> listOfDietPlanReports = dataLayer.GetDietPlanReportsWithinDates(userID, clientID, skip, take, fromDate, toDate);
                List<BODietPlan> dietPlanReports = GetDietPlanReportBOForDietPlanReportDBObjects(listOfDietPlanReports);
                return dietPlanReports;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private List<BODietPlan> GetDietPlanReportBOForDietPlanReportDBObjects(List<DietPlanReport> dietPlanReports)
        {
            List<BODietPlan> listOfDietPlanReports = new List<BODietPlan>();
            if (dietPlanReports.Count > 0)
            {
                foreach (DietPlanReport dietPlanReport in dietPlanReports)
                {
                    BODietPlan dietPlanReportObject = new BODietPlan();
                    dietPlanReportObject.DietPlanReportID = dietPlanReport.DietPlanReportID;
                    dietPlanReportObject.TestDate = dietPlanReport.TestDate;
                    dietPlanReportObject.BMI = dietPlanReport.BMI;
                    dietPlanReportObject.Morning = dietPlanReport.Morning;
                    dietPlanReportObject.Afternoon = dietPlanReport.Afternoon;
                    dietPlanReportObject.Evening = dietPlanReport.Evening;
                    dietPlanReportObject.Night = dietPlanReport.Night;
                    listOfDietPlanReports.Add(dietPlanReportObject);
                }
            }
            return listOfDietPlanReports;
        }

        public bool SaveNote(int clientID, string note)
        {
            try
            {
                DataLayerManager dataLayer = new DataLayerManager();
                return dataLayer.SaveNote(clientID, note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetNoteForClient(int clientID)
        {
            try
            {
                DataLayerManager dataLayer = new DataLayerManager();
                string note = dataLayer.GetNoteForClient(clientID);
                if (note == null)
                {
                    note = "No Note";
                }
                return note;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ObservableCollection<BOLabTest> GetLabTestTypesForUser(int userID)
        {
            try
            {
                DataLayerManager dataLayer = new DataLayerManager();
                List<ReportFieldMaster> listOfLabTestTypes = dataLayer.GetAllLabTestTypes();
                List<ReportFieldMaster> listOfLabTestTypesForUser = dataLayer.GetLabTestTypesForUser(userID);

                ObservableCollection<BOLabTest> listOfLabTests = new ObservableCollection<BOLabTest>();

                if (listOfLabTestTypes.Count > 0)
                {
                    foreach (ReportFieldMaster reportField in listOfLabTestTypes)
                    {
                        BOLabTest labTest = new BOLabTest();
                        labTest.LabTestID = reportField.ReportFieldID;
                        labTest.LabTest = reportField.ReportFieldName;
                        labTest.IsSelected = (from obj in listOfLabTestTypesForUser where obj.ReportFieldID == reportField.ReportFieldID select true).FirstOrDefault();
                        listOfLabTests.Add(labTest);
                    }
                }
                return listOfLabTests;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private ObservableCollection<BOLabTest> GetLabTestsForReportFields(List<ReportFieldMaster> reportFields)
        {
            try
            {
                ObservableCollection<BOLabTest> listOfLabTests = new ObservableCollection<BOLabTest>();
                if (reportFields.Count > 0)
                {
                    foreach (ReportFieldMaster reportField in reportFields)
                    {
                        BOLabTest labTest = new BOLabTest();
                        labTest.LabTestID = reportField.ReportFieldID;
                        labTest.LabTest = reportField.ReportFieldName;
                        listOfLabTests.Add(labTest);
                    }
                }
                return listOfLabTests;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool SaveLabTests(int userID, List<BOLabTest> listOfUpdatedTests)
        {
            try
            {
                DataLayerManager dataLayer = new DataLayerManager();
                List<int> deleteTestsForUser = new List<int>();
                List<int> addTestsForUser = new List<int>();
                List<ReportFieldMaster> existingReportFields = dataLayer.GetLabTestTypesForUser(userID);
                if (existingReportFields.Count > 0)
                {
                    if (listOfUpdatedTests.Count > 0)
                    {
                        foreach (BOLabTest test in listOfUpdatedTests)
                        {
                            ReportFieldMaster reportField = (from field in existingReportFields
                                                             where field.ReportFieldID == test.LabTestID
                                                             select field).FirstOrDefault();
                            if (reportField != null)
                            {
                                if (test.IsSelected == false)
                                {
                                    deleteTestsForUser.Add(test.LabTestID);
                                }
                            }
                            else
                            {
                                if (test.IsSelected == true)
                                {
                                    addTestsForUser.Add(test.LabTestID);
                                }
                            }
                        }
                    }
                }
                else
                {
                    addTestsForUser = (from labTest in listOfUpdatedTests
                                       where labTest.IsSelected == true
                                       select labTest.LabTestID).ToList();
                }
                return dataLayer.SaveLabTests(userID, deleteTestsForUser, addTestsForUser);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool AddClient(string clientName, long phone, string address, int userID, int categoryID)
        {
            try
            {
                DataLayerManager dataLayer = new DataLayerManager();
                bool isClientAdded = dataLayer.AddClient(clientName, phone, address, userID, categoryID);
                return isClientAdded;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SaveTestForUser(int userID, string testName)
        {
            DataLayerManager dataLayer = new DataLayerManager();
            bool saveSuccessful = dataLayer.SaveTestForUser(userID, testName);
            return saveSuccessful;
        }

        public Hashtable GetLabReportsForCategoriesForReports(List<int> categoryIDs, List<int> reportFieldIDs, DateTime fromDate, DateTime tilDate, int userID)
        {
            Hashtable listOfCategoriesReportsHasTable = new Hashtable();
            if (categoryIDs.Count > 0)
            {
                foreach (int categoryID in categoryIDs)
                {
                    Hashtable labReports = this.GetLabReportsForCategoryForReports(categoryID, reportFieldIDs, userID);
                    listOfCategoriesReportsHasTable.Remove(categoryID);
                    listOfCategoriesReportsHasTable.Add(categoryID, labReports);
                }
            }
            return listOfCategoriesReportsHasTable;
        }

        public Hashtable GetLabReportsForCategoryForReports(int categoryID, List<int> reportIDs, int userID)
        {
            Hashtable listOfClientsReportsHasTable = new Hashtable();
            if (reportIDs.Count > 0)
            {
                foreach (int reportID in reportIDs)
                {
                    Hashtable labReports = this.GetLabReportsForCategory(categoryID, reportID, userID);
                    listOfClientsReportsHasTable.Remove(reportID);
                    listOfClientsReportsHasTable.Add(reportID, labReports);
                }
            }
            return listOfClientsReportsHasTable;
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
    }
}
