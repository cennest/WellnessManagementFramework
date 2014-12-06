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
