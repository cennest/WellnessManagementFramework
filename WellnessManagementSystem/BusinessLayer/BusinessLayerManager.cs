using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DatabaseEntities;
using BusinessLayer.Entities;


namespace BusinessLayer
{
    public class BusinessLayerManager
    {
        public UserDetails GetUser(string userName, string password)
        {
            try
            {
            DataLayerManager datalayer = new DataLayerManager();
            User user = datalayer.GetUser(userName, password);

            if (user != null)
            {
                UserDetails appUser = new UserDetails();
                appUser.UserID = user.UserId;
                appUser.UserName = user.UserName;

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
