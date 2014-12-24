﻿using System;
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
        private BOUser userDetails;
        private List<BOUserField> labReportFieldsForUser;
        public int currentClientID {get;set;}
        public string CurrentClientName { get; set; }

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

        public void SetUserDetails(BOUser userDetails)
        {
            this.userDetails = userDetails;
        }

        public BOUser GetUserDetails()
        {
            return this.userDetails;
        }

        public void SetLabReportFieldsForUser(List<BOUserField> labReportFields)
        {
            this.labReportFieldsForUser = labReportFields;
        }

        public List<BOUserField> GetLabReportFieldsForUser()
        {
            return this.labReportFieldsForUser;
        }

        public bool BreadCrumbSelected(string crumb)
        {
            switch (crumb)
            {
                case "Home":
                    {
                        HomePage home = new HomePage();
                        home.Show();
                      
                    }
                    break;
                case "All Athletes":
                    {
                        AllClientNotification clientPage = new AllClientNotification();
                        clientPage.Show();
                     
                    }
                    break;
            }
            return true;
        }
    }
}
