using BusinessLayer;
using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PhysioApplication
{
    /// <summary>
    /// Interaction logic for LabTestsScreen.xaml
    /// </summary>
    public partial class LabTestsScreen : Window
    {
        BusinessLayerManager businessLayer;
        int userID;
        public LabTestsScreen()
        {
            InitializeComponent();
            businessLayer = new BusinessLayerManager();
            AppManager appManager = AppManager.getInstance();
            appManager.CurrentWindow = this;
            SetLogOut();
            SetBreadCrumb();
            GetAllTests();
        }

        private void SetLogOut()
        {
            this.ucLogoutUC.OnLogout += new EventHandler(ucLogoutUC_OnLogout);
        }

        public void ucLogoutUC_OnLogout(object sender, EventArgs e)
        {
            AppManager.getInstance().LogOut();

        }
        private void GetAllTests()
        {
            AppManager appManager = AppManager.getInstance();
            int userID = appManager.GetUserDetails().UserID;
            ObservableCollection<BOLabTest> listOfTests = businessLayer.GetLabTestTypesForUser(userID);
            this.DataContext = listOfTests;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<BOLabTest> editedReports = (ObservableCollection<BOLabTest>)listOfTests.DataContext;
            
            if (editedReports.Count > 0)
            {
                List<BOLabTest> labTests = new List<BOLabTest>();
                foreach (BOLabTest test in editedReports)
                {
                    labTests.Add(test);
                }

                AppManager appManager = AppManager.getInstance();
                int userID = appManager.GetUserDetails().UserID;
                bool saved = businessLayer.SaveLabTests(userID, labTests);
                if (saved == true)
                {
                    MessageBox.Show("Saved successfully");
                }
            }
        }

        private void AddNewTests_Click(object sender, RoutedEventArgs e)
        {
            AddNewTest addtest = new AddNewTest();
            addtest.ShowDialog();
        }

        private void SetBreadCrumb()
        {
            List<string> headers = new List<string> { "Home", "Settings","Tests" };
            ucBreadCrumb.ResetBreadCrumb(headers);
            ucBreadCrumb.CrumbSelected += ucBreadCrumb_CrumbSelected;
        }

        void ucBreadCrumb_CrumbSelected(string selectedString)
        {
            AppManager.getInstance().BreadCrumbSelected(selectedString);
        }

        private void CheckBoxZone_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
