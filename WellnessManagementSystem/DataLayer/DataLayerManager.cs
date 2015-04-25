using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseEntities;


namespace DataLayer
{
    public class DataLayerManager
    {
        public List<LabReport> GetLabReportsForClient(int clientID, int userID)
        {
            try
            {
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
                List<LabReport> listOfLabReports = (from labReport in dataContext.LabReports
                                                    where labReport.UserID == userID && labReport.ClientID == clientID
                                                    select labReport).OrderByDescending(t => t.TestDate).ToList();

                return listOfLabReports;
            }
            catch (Exception exception)
            {
                throw (exception);
            }
        }


        public List<LabReport> GetLabReportsForClientForDateRange(int clientID, int userID, DateTime fromDate, DateTime toDate)
        {
            try
            {
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
                List<LabReport> listOfLabReports = (from labReport in dataContext.LabReports
                                                    where labReport.UserID == userID && labReport.ClientID == clientID
                                                    && labReport.TestDate >= fromDate && labReport.TestDate <= toDate
                                                    select labReport).OrderByDescending(t => t.TestDate).ToList();

                return listOfLabReports;
            }
            catch (Exception exception)
            {
                throw (exception);
            }
        }

        public List<UserReportField> GetUserFields(int userID)
        {
            try
            {
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
                List<UserReportField> listOfUserReportFields = (from userReportField in dataContext.UserReportFields
                                                                where userReportField.UserID == userID
                                                                select userReportField).ToList();
                return listOfUserReportFields;
            }
            catch (Exception exception)
            {
                throw (exception);
            }
        }
        public User GetUser(string userName, string password)
        {
            try
            {
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
                User user = (from appUser in dataContext.Users
                             where appUser.UserName.ToLower() == userName.ToLower() && appUser.Password == password
                             select appUser).FirstOrDefault();
                return user;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<CategoryMaster> GetAllCategories()
        {
            try
            {
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
                List<CategoryMaster> listOfCategories = (from category in dataContext.CategoryMasters
                                                         select category).ToList();
                return listOfCategories;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<Client> GetClientsForCategories(int categoryID, int userID, int skip, int take)
        {
            try
            {
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
                List<Client> listOfClients = null;
                if (categoryID == Convert.ToInt32(Category.AllSports))
                {
                    listOfClients = (from client in dataContext.Clients
                                     where client.UserID == userID
                                     select client).Skip(skip).Take(take).ToList();
                }
                else
                {
                    listOfClients = (from client in dataContext.Clients
                                     where client.UserID == userID && client.CategoryID == categoryID
                                     select client).Skip(skip).Take(take).ToList();
                }
                return listOfClients;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<Client> GetClientsForCategory(int categoryID, int userID)
        {
            try
            {
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();

                List<Client> listOfClients = (from client in dataContext.Clients
                                              where client.UserID == userID && client.CategoryID == categoryID
                                              select client).ToList();
                return listOfClients;
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
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
                int countOfClients = 0;
                if (categoryID == Convert.ToInt32(Category.AllSports))
                {
                    countOfClients = (from client in dataContext.Clients
                                      where client.UserID == userID
                                      select client).Count();
                }
                else
                {
                    countOfClients = (from client in dataContext.Clients
                                      where client.UserID == userID && client.CategoryID == categoryID
                                      select client).Count();
                }
                return countOfClients;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<Client> GetClientsForCategoryByName(int categoryID, string searchString, int userID, int skip, int take)
        {
            try
            {
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
                List<Client> listOfClients = null;
                if (categoryID == Convert.ToInt32(Category.AllSports))
                {
                    listOfClients = (from client in dataContext.Clients
                                     where client.UserID == userID && client.ClientName.ToLower().Contains(searchString.ToLower())
                                     select client).Skip(skip).Take(take).ToList();
                }
                else
                {
                    listOfClients = (from client in dataContext.Clients
                                     where client.UserID == userID && client.CategoryID == categoryID && client.ClientName.ToLower().Contains(searchString.ToLower())
                                     select client).Skip(skip).Take(take).ToList();
                }
                return listOfClients;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public DateTime? GetLastLabReportDateForClient(int clientID)
        {
            try
            {
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
                DateTime? labReportDate = (from report in dataContext.LabReports
                                          where report.ClientID == clientID
                                          select (DateTime?)report.TestDate).Max();
               return labReportDate;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int GetCountOfClientsForCategoryByName(int categoryID, string searchString, int userID)
        {
            try
            {
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
                int countOfClients = 0;
                if (categoryID == Convert.ToInt32(Category.AllSports))
                {
                    countOfClients = (from client in dataContext.Clients
                                      where client.UserID == userID && client.ClientName.ToLower().Contains(searchString.ToLower())
                                      select client).Count();
                }
                else
                {
                    countOfClients = (from client in dataContext.Clients
                                      where client.UserID == userID && client.CategoryID == categoryID && client.ClientName.ToLower().Contains(searchString.ToLower())
                                      select client).Count();
                }
                return countOfClients;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        private List<DateTime> GetAllReportDatesForClient(int clientID)
        {
            WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
            var dateList = (from report in dataContext.LabReports
                            where report.ClientID == clientID
                            select report.TestDate).Distinct().ToList();
            return dateList;

        }

        public bool SaveLabReportsForClient(List<LabReport> labReports, int clientID, int userID)
        {
            WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();

            foreach (LabReport report in labReports)
            {
                LabReport existingDBReport = (from dbRecord in dataContext.LabReports
                                              where dbRecord.ClientID == clientID && dbRecord.TestDate == report.TestDate && dbRecord.ReportFieldID == report.ReportFieldID
                                              select dbRecord).FirstOrDefault();
                if (existingDBReport != null)
                {
                    existingDBReport.ReportFieldValue = report.ReportFieldValue;
                }
                else
                {
                    report.ClientID = clientID;
                    report.UserID = userID;//Change this
                    dataContext.LabReports.InsertOnSubmit(report);
                }
                dataContext.SubmitChanges();
            }

            //check if any dates have been completely removed
            List<DateTime> presentDates = labReports.Select(l => l.TestDate).Distinct().ToList();
            List<DateTime> dbDates = GetAllReportDatesForClient(clientID);
            List<DateTime> removedDates = dbDates.Except(presentDates).ToList();

            foreach (DateTime date in removedDates)
            {
                List<LabReport> existingDBReports = (from dbRecord in dataContext.LabReports
                                                     where dbRecord.ClientID == clientID && dbRecord.TestDate == date
                                                     select dbRecord).ToList();
                dataContext.LabReports.DeleteAllOnSubmit(existingDBReports);
                dataContext.SubmitChanges();

            }

            return true;
        }

        public bool SavePhysicalConditionReportsForClient(List<int> deletedPhysicalConditionList, List<PhysicalConditionReport> currentPhysicalConditionList, int clientID, int userID)
        {
            try
            {
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();

                foreach (PhysicalConditionReport physicalConditionReport in currentPhysicalConditionList)
                {
                    PhysicalConditionReport existingReport = (from dbRecord in dataContext.PhysicalConditionReports
                                                              where dbRecord.PhysicalConditionReportID == physicalConditionReport.PhysicalConditionReportID
                                                              select dbRecord).FirstOrDefault();
                    if (existingReport != null)
                    {
                        existingReport.TestDate = physicalConditionReport.TestDate;
                        existingReport.MSKAssessmentImpressions = physicalConditionReport.MSKAssessmentImpressions;
                        existingReport.Advice = physicalConditionReport.Advice;
                    }
                    else
                    {
                        physicalConditionReport.UserID = userID;
                        physicalConditionReport.ClientID = clientID;
                        dataContext.PhysicalConditionReports.InsertOnSubmit(physicalConditionReport);
                    }
                    dataContext.SubmitChanges();
                }

                //deletion
                List<PhysicalConditionReport> physicalConditionReportlistToBeDeleted = new List<PhysicalConditionReport>();
                foreach (int physicalConditionID in deletedPhysicalConditionList)
                {
                    PhysicalConditionReport physicalConditionReport = (from physicalConditionReportObj in dataContext.PhysicalConditionReports
                                                                       where physicalConditionReportObj.PhysicalConditionReportID == physicalConditionID
                                                                       select physicalConditionReportObj).FirstOrDefault();
                    if (physicalConditionReport != null)
                    {
                        physicalConditionReportlistToBeDeleted.Add(physicalConditionReport);
                    }
                }
                if (physicalConditionReportlistToBeDeleted.Count > 0)
                {
                    dataContext.PhysicalConditionReports.DeleteAllOnSubmit(physicalConditionReportlistToBeDeleted);
                    dataContext.SubmitChanges();
                }

                return true;
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);

            }

        }

        public List<PhysicalConditionReport> GetPhysicalConditioningReportsWithinDates(int userID, int clientID, int skip, int take, DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
                List<PhysicalConditionReport> listOfPhysicalConditioningReports = null;
                if (fromDate != null && toDate == null)
                {
                    listOfPhysicalConditioningReports = (from physicalConditioningReport in dataContext.PhysicalConditionReports
                                                         where physicalConditioningReport.UserID == userID && physicalConditioningReport.ClientID == clientID && physicalConditioningReport.TestDate >= fromDate && physicalConditioningReport.TestDate <= DateTime.Now.Date 
                                                         orderby physicalConditioningReport.TestDate descending
                                                         select physicalConditioningReport).Skip(skip).Take(take).ToList();
                }
                else if (fromDate == null && toDate != null)
                {
                    listOfPhysicalConditioningReports = (from physicalConditioningReport in dataContext.PhysicalConditionReports
                                                         where physicalConditioningReport.UserID == userID && physicalConditioningReport.ClientID == clientID && physicalConditioningReport.TestDate <= DateTime.Now.Date
                                                         orderby physicalConditioningReport.TestDate descending
                                                         select physicalConditioningReport).Skip(skip).Take(take).ToList();
                }
                else if (fromDate != null && toDate != null)
                {
                    listOfPhysicalConditioningReports = (from physicalConditioningReport in dataContext.PhysicalConditionReports
                                                         where physicalConditioningReport.UserID == userID && physicalConditioningReport.ClientID == clientID && physicalConditioningReport.TestDate >= fromDate && physicalConditioningReport.TestDate <= toDate
                                                         orderby physicalConditioningReport.TestDate descending
                                                         select physicalConditioningReport).Skip(skip).Take(take).ToList();
                }
                else
                {
                    listOfPhysicalConditioningReports = (from physicalConditioningReport in dataContext.PhysicalConditionReports
                                                         where physicalConditioningReport.UserID == userID && physicalConditioningReport.ClientID == clientID
                                                         orderby physicalConditioningReport.TestDate descending
                                                         select physicalConditioningReport).Skip(skip).Take(take).ToList();
                } 
                return listOfPhysicalConditioningReports;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int GetPhysicalConditioningReportsCount(int userID, int clientID, DateTime? fromDate, DateTime? toDate)
        {
            WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
            int count = 0;
            if (fromDate != null && toDate == null)
            {
                count = (from physicalConditioningReport in dataContext.PhysicalConditionReports
                         where physicalConditioningReport.UserID == userID && physicalConditioningReport.ClientID == clientID && physicalConditioningReport.TestDate >= fromDate && physicalConditioningReport.TestDate <= DateTime.Now.Date
                         select physicalConditioningReport).Count();
            }
            else if (fromDate == null && toDate != null)
            {
                count = (from physicalConditioningReport in dataContext.PhysicalConditionReports
                         where physicalConditioningReport.UserID == userID && physicalConditioningReport.ClientID == clientID && physicalConditioningReport.TestDate <= DateTime.Now.Date
                         select physicalConditioningReport).Count();
            }
            else if (fromDate != null && toDate != null)
            {
                count = (from physicalConditioningReport in dataContext.PhysicalConditionReports
                         where physicalConditioningReport.UserID == userID && physicalConditioningReport.ClientID == clientID && physicalConditioningReport.TestDate >= fromDate && physicalConditioningReport.TestDate <= toDate
                         select physicalConditioningReport).Count();
            }
            else 
            {
                count = (from physicalConditioningReport in dataContext.PhysicalConditionReports
                         where physicalConditioningReport.UserID == userID && physicalConditioningReport.ClientID == clientID
                         select physicalConditioningReport).Count();
            }
            return count;
        }

        public List<PhysicalConditionReport> GetPhysicalConditioningReportsForCategoryByName(int userID, int clientID, int categoryID, string searchString, DateTime? fromDate, DateTime? toDate, int skip, int take)
        {
            try
            {
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
                List<PhysicalConditionReport> listOfPhysicalConditioningReports = null;
                if (fromDate == null || toDate == null)
                {
                    listOfPhysicalConditioningReports = (from physicalConditioningReport in dataContext.PhysicalConditionReports
                                                         where physicalConditioningReport.UserID == userID && physicalConditioningReport.Client.CategoryID == categoryID && physicalConditioningReport.Client.ClientName.ToLower() == searchString.ToLower()
                                                         orderby physicalConditioningReport.TestDate descending
                                                         select physicalConditioningReport).Skip(skip).Take(take).ToList();
                }
                else
                {
                    listOfPhysicalConditioningReports = (from physicalConditioningReport in dataContext.PhysicalConditionReports
                                                         where physicalConditioningReport.UserID == userID &&
                                                         physicalConditioningReport.Client.CategoryID == categoryID &&
                                                         physicalConditioningReport.Client.ClientName.ToLower() == searchString.ToLower() &&
                                                         physicalConditioningReport.TestDate >= fromDate &&
                                                         physicalConditioningReport.TestDate <= toDate
                                                         orderby physicalConditioningReport.TestDate descending
                                                         select physicalConditioningReport).Skip(skip).Take(take).ToList();
                }
                return listOfPhysicalConditioningReports;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool SaveDietPlanReportsForClient(List<int> deletedDietPlanList, List<DietPlanReport> currentDietPlanList, int clientID, int userID)
        {
            try
            {
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();

                foreach (DietPlanReport dietPlanReport in currentDietPlanList)
                {
                    DietPlanReport existingReport = (from dbRecord in dataContext.DietPlanReports
                                                     where dbRecord.DietPlanReportID == dietPlanReport.DietPlanReportID
                                                              select dbRecord).FirstOrDefault();
                    if (existingReport != null)
                    {
                        existingReport.TestDate = dietPlanReport.TestDate;
                        existingReport.BMI = dietPlanReport.BMI;
                        existingReport.Morning = dietPlanReport.Morning;
                        existingReport.Afternoon = dietPlanReport.Afternoon;
                        existingReport.Evening = dietPlanReport.Evening;
                        existingReport.Night = dietPlanReport.Night;
                    }
                    else
                    {
                        dietPlanReport.UserID = userID;
                        dietPlanReport.ClientID = clientID;
                        dataContext.DietPlanReports.InsertOnSubmit(dietPlanReport);
                    }
                    dataContext.SubmitChanges();
                }

                //deletion
                List<DietPlanReport> dietPlanReportlistToBeDeleted = new List<DietPlanReport>();
                foreach (int dietPlanReportID in deletedDietPlanList)
                {
                    DietPlanReport dietPlanReport = (from dietPlanReportObj in dataContext.DietPlanReports
                                                     where dietPlanReportObj.DietPlanReportID == dietPlanReportID
                                                     select dietPlanReportObj).FirstOrDefault();
                    if (dietPlanReport != null)
                    {
                        dietPlanReportlistToBeDeleted.Add(dietPlanReport);
                    }
                }
                if (dietPlanReportlistToBeDeleted.Count > 0)
                {
                    dataContext.DietPlanReports.DeleteAllOnSubmit(dietPlanReportlistToBeDeleted);
                    dataContext.SubmitChanges();
                }

                return true;
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);

            }

        }

        public List<DietPlanReport> GetDietPlanReportsWithinDates(int userID, int clientID, int skip, int take, DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
                List<DietPlanReport> listOfDietPlanReports = null;
                if (fromDate != null && toDate == null)
                {
                    listOfDietPlanReports = (from dietPlanReport in dataContext.DietPlanReports
                                             where dietPlanReport.UserID == userID && dietPlanReport.ClientID == clientID 
                                             && dietPlanReport.TestDate >= fromDate && dietPlanReport.TestDate <= DateTime.Now.Date
                                             orderby dietPlanReport.TestDate descending
                                             select dietPlanReport).Skip(skip).Take(take).ToList();
                }
                else if (fromDate == null && toDate != null)
                {
                    listOfDietPlanReports = (from dietPlanReport in dataContext.DietPlanReports
                                                         where dietPlanReport.UserID == userID && dietPlanReport.ClientID == clientID 
                                                         && dietPlanReport.TestDate <= DateTime.Now.Date
                                                         orderby dietPlanReport.TestDate descending
                                                         select dietPlanReport).Skip(skip).Take(take).ToList();
                }
                else if (fromDate != null && toDate != null)
                {
                    listOfDietPlanReports = (from dietPlanReport in dataContext.DietPlanReports
                                                         where dietPlanReport.UserID == userID && dietPlanReport.ClientID == clientID 
                                                         && dietPlanReport.TestDate >= fromDate && dietPlanReport.TestDate <= toDate
                                                         orderby dietPlanReport.TestDate descending
                                                         select dietPlanReport).Skip(skip).Take(take).ToList();
                }
                else
                {
                    listOfDietPlanReports = (from dietPlanReport in dataContext.DietPlanReports
                                                         where dietPlanReport.UserID == userID && dietPlanReport.ClientID == clientID
                                                         orderby dietPlanReport.TestDate descending
                                                         select dietPlanReport).Skip(skip).Take(take).ToList();
                }
                return listOfDietPlanReports;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int GetDietPlanReportsCount(int userID, int clientID, DateTime? fromDate, DateTime? toDate)
        {
            WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
            int count = 0;
            if (fromDate != null && toDate == null)
            {
                count = (from dietPlanReport in dataContext.DietPlanReports
                         where dietPlanReport.UserID == userID && dietPlanReport.ClientID == clientID
                         && dietPlanReport.TestDate >= fromDate && dietPlanReport.TestDate <= DateTime.Now.Date
                         select dietPlanReport).Count();
            }
            else if (fromDate == null && toDate != null)
            {
                count = (from dietPlanReport in dataContext.DietPlanReports
                         where dietPlanReport.UserID == userID && dietPlanReport.ClientID == clientID && dietPlanReport.TestDate <= DateTime.Now.Date
                         select dietPlanReport).Count();
            }
            else if (fromDate != null && toDate != null)
            {
                count = (from dietPlanReport in dataContext.DietPlanReports
                         where dietPlanReport.UserID == userID && dietPlanReport.ClientID == clientID && dietPlanReport.TestDate >= fromDate && dietPlanReport.TestDate <= toDate
                         select dietPlanReport).Count();
            }
            else 
            {
                count = (from dietPlanReport in dataContext.DietPlanReports
                         where dietPlanReport.UserID == userID && dietPlanReport.ClientID == clientID
                         select dietPlanReport).Count();
            }
            return count;
        }

        public bool SaveNote(int clientID, string note)
        {
            WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
            Client client = (from clientObj in dataContext.Clients
                             where clientObj.ClientID == clientID
                             select clientObj).FirstOrDefault();
            if (client != null)
            {
                client.Notes = note;
                dataContext.SubmitChanges();
                return true;
            }
            return false;
        }

        public string GetNoteForClient(int clientID)
        {
            WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
            Client client = (from clientObj in dataContext.Clients
                             where clientObj.ClientID == clientID
                             select clientObj).FirstOrDefault();
            return client.Notes;
        }

        public List<ReportFieldMaster> GetAllLabTestTypes()
        {
            try
            {
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
                List<ReportFieldMaster> listOfReportFields = (from test in dataContext.ReportFieldMasters
                                                              where test.ReportTypeID == Convert.ToInt32(ReportType.LabReport)
                                                              select test).ToList();
                return listOfReportFields;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ReportFieldMaster> GetLabTestTypesForUser(int userID)
        {
            try
            {
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
                List<ReportFieldMaster> listOfReportFields = (from test in dataContext.UserReportFields
                                                              where test.ReportFieldMaster.ReportTypeID == Convert.ToInt32(ReportType.LabReport) && test.UserID == userID 
                                                              select test.ReportFieldMaster).ToList();
                return listOfReportFields;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

      

        public bool SaveLabTests(int userID, List<int> deleteLabTestForUser, List<int> newAddedLabTestsForUser)
        {
            try
            {
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
                if (newAddedLabTestsForUser.Count > 0)
                {
                    foreach (int labTestID in newAddedLabTestsForUser)
                    {
                        UserReportField reportField = new UserReportField();
                        reportField.UserID = userID;
                        reportField.ReportFieldID = labTestID;
                        dataContext.UserReportFields.InsertOnSubmit(reportField);
                        dataContext.SubmitChanges();
                    }
                }
                if (deleteLabTestForUser.Count > 0)
                {
                    foreach (int labTestID in deleteLabTestForUser)
                    {
                        UserReportField reportField = (from field in dataContext.UserReportFields
                                                       where field.ReportFieldID == labTestID
                                                       select field).FirstOrDefault();
                        if (reportField != null)
                        {
                            dataContext.UserReportFields.DeleteOnSubmit(reportField);
                        }
                    }
                    dataContext.SubmitChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        
 
        public bool AddClient(string clientName, long phone, string address, int userID, int categoryID)
        {
            try
            {
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
                Client client = new Client();
                client.ClientName = clientName;
                client.ClientPhone = phone.ToString();
                client.ClientAddress = address;
                client.UserID = userID;
                client.CategoryID = categoryID;
                client.Notes = "";
                dataContext.Clients.InsertOnSubmit(client);
                dataContext.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public int SaveTestForUser(int userID, string testName)
        {
            try
            {
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
                ReportFieldMaster reportFieldMaster = new ReportFieldMaster();
                reportFieldMaster.ReportFieldName = testName;
                reportFieldMaster.ReportTypeID = 1;
                bool testExists=CheckTestAlreadyExists(testName);
                if (!testExists)
                {
                    dataContext.ReportFieldMasters.InsertOnSubmit(reportFieldMaster);
                    dataContext.SubmitChanges();
                    if (reportFieldMaster.ReportFieldID != 0)
                    {
                        UserReportField userReportField = new UserReportField();
                        userReportField.UserID = userID;
                        userReportField.ReportFieldID = reportFieldMaster.ReportFieldID;
                        dataContext.UserReportFields.InsertOnSubmit(userReportField);
                        dataContext.SubmitChanges();
                    }
                    return reportFieldMaster.ReportFieldID;
                }
                else
                {
                    throw new Exception("Test already Exists");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public bool CheckTestAlreadyExists(string testName)
        {
            try 
            { 
            WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
            ReportFieldMaster reportField = (from field in dataContext.ReportFieldMasters
                                           where field.ReportFieldName == testName
                                           select field).FirstOrDefault();
           if(reportField!=null)
           {
               return true;
           }
           else
           {
               return false;
           }
            }catch(Exception exception)
            {
                throw exception;
            }
        }

        public List<int> GetClientsForCategoryID(int categoryID, int userID)
        {
            try
            {
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
                List<int> listOfClientIDs = null;
                if (categoryID == Convert.ToInt32(Category.AllSports))
                {
                    listOfClientIDs = (from client in dataContext.Clients
                                       where client.UserID == userID
                                       select client.ClientID).ToList();
                }
                else
                {
                    listOfClientIDs = (from client in dataContext.Clients
                                       where client.UserID == userID && client.CategoryID == categoryID
                                       select client.ClientID).ToList();
                }
                return listOfClientIDs;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<LabReport> GetLabReportsForClientID(int clientID, int userID, int reportID)
        {
            try
            {
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
                List<LabReport> listOfLabReports = (from labReport in dataContext.LabReports
                                                    where labReport.UserID == userID && labReport.ClientID == clientID
                                                    && labReport.ReportFieldID == reportID
                                                    select labReport).OrderByDescending(t => t.TestDate).ToList();

                return listOfLabReports;
            }
            catch (Exception exception)
            {
                throw (exception);
            }
        }
    }
}
