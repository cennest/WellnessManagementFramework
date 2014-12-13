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
        public List<LabReport> GetLabReportsForClient(int clientID,int userID)
        {
            try
            {
                WellnessManagementFrameworkDBMLDataContext dataContext = new WellnessManagementFrameworkDBMLDataContext();
                List<LabReport> listOfLabReports = (from labReport in dataContext.LabReports
                                                    where labReport.UserID == userID && labReport.ClientID == clientID
                                                    select labReport).ToList();

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
                                                    && labReport.TestDate>=fromDate && labReport.TestDate<=toDate
                                                    select labReport).ToList();

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
      
    }
}
