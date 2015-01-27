﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Entities;
using System.Windows;
using BusinessLayer;

namespace PhysioApplication
{
    public class AppManager
    {
        private List<BOCategory> appManagerCategories;
        public List<BOCategory> CurrentCategories
        {
            get
            {
                
                if (appManagerCategories == null)
                {
                    BusinessLayerManager businessLayer = new BusinessLayerManager();
                    appManagerCategories = businessLayer.GetAllCategories();

                }
                return appManagerCategories;

            }
        }
            
            
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

        public Window CurrentWindow
        { get; set; }

      
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
                        Window previousWindow = CurrentWindow;
                        HomePage home = new HomePage();
                        if (previousWindow != null)
                        {
                            previousWindow.Close();
                        }
                        home.Show();
                      
                    }
                    break;
                case "All Athletes":
                    {
                        Window previousWindow = CurrentWindow;
                        AllClientNotification clientPage = new AllClientNotification();
                        if (previousWindow != null)
                        {
                            previousWindow.Close();
                        }
                        clientPage.Show();
                     
                    }
                    break;
            }
            return true;
        }

        public void SearchSelected(int selectedIndex, string searchText)
        {
            Window previousWindow = CurrentWindow;
            AllClientNotification allClientNotifications = new AllClientNotification();
            allClientNotifications.ucFilterUC.ComboBoxPageFilter.SelectedIndex = selectedIndex;
            allClientNotifications.ucFilterUC.SearchTextBlock.Text = searchText;
            allClientNotifications.ReloadData(true, searchText);
            if (previousWindow != null)
            {
                previousWindow.Close();
            }
            allClientNotifications.Show();
           
        }
    }
}
