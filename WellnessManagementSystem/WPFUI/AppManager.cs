using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysioApplication
{
    public class AppManager
    {
        private static AppManager instance = null;
        private int UserID;
        private string UserName;

        private AppManager()
        {

        }

        public static AppManager getInstance()
        {
            if (instance == null)
            {
                instance = new AppManager();
            }
            return instance;
        }

        public void SetUserName(string userName)
        {
            this.UserName = userName;
        }

        public string GetUserName()
        {
            return this.UserName;
        }

        public void setUserID(int userID)
        {
            this.UserID = userID;
        }

        public int GetUserID()
        {
            return this.UserID;
        }
    }
}
