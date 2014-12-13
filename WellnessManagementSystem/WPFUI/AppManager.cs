using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Entities;

namespace PhysioApplication
{
    public class AppManager
    {
        private static AppManager instance = null;
        private UserDetails userDetails;

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

        public void SetUserDetails(UserDetails userDetails)
        {
            this.userDetails = userDetails;
        }

        public UserDetails GetUserDetails()
        {
            return this.userDetails;
        }
    }
}
