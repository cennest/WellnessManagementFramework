using System;
using System.Collections.Generic;
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
using BusinessLayer;
using BusinessLayer.Entities;
using System.Collections.ObjectModel;

namespace PhysioApplication
{
    /// <summary>
    /// Interaction logic for HistoricalTrends.xaml
    /// </summary>
    public partial class HistoricalTrends : Window
    {
        DateTime? fromSelectedDate;
        DateTime? toSelectedDate;
        public HistoricalTrends()
        {
            InitializeComponent();
            AppManager appManager = AppManager.getInstance();
            appManager.CurrentWindow = this;
            SetLogOut();
            SetBreadCrumb();
            LoadControls();
        }

        private void LoadControls()
        {
            BusinessLayerManager businessLayer = new BusinessLayerManager();
            this.DataContext = businessLayer.GetLabTestsForUser(AppManager.getInstance().GetUserDetails().UserID);
            LoadCategories();
        }

        private void LoadCategories()
        {
            var appManagerCategories = AppManager.getInstance().CurrentCategories;

            List<ComboBoxItem> comboBoxItemList = new List<ComboBoxItem>();
            foreach (BOCategory category in appManagerCategories)
            {
                comboBoxItemList.Add(new ComboBoxItem { Content = category.CategoryName, Tag = category.CategoryID.ToString() });
            }
            this.cbCategories.ItemsSource = comboBoxItemList;
            this.cbCategories.SelectedIndex = 0;
        }

        private void FromDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fromSelectedDate = FromDate.SelectedDate;
        }

        private void ToDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            toSelectedDate = ToDate.SelectedDate;
        }

        private void SetBreadCrumb()
        {
            List<string> headers = new List<string> { "Home", "Historical Trends" };
            ucBreadCrumb.ResetBreadCrumb(headers);
            ucBreadCrumb.CrumbSelected += ucBreadCrumb_CrumbSelected;
        }

        void ucBreadCrumb_CrumbSelected(string selectedString)
        {
            AppManager.getInstance().BreadCrumbSelected(selectedString);
        }

        private void SetLogOut()
        {
            this.ucLogoutUC.OnLogout += new EventHandler(ucLogoutUC_OnLogout);
        }

        public void ucLogoutUC_OnLogout(object sender, EventArgs e)
        {
            AppManager.getInstance().LogOut();

        }

        private void reportBtn_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<BOLabTest> editedLabTests = (ObservableCollection<BOLabTest>)listOfTests.DataContext;
            List<BOLabTest> selectedTests = new List<BOLabTest>();
            foreach (BOLabTest test in editedLabTests)
            {
                if (test.IsSelected)
                {
                    selectedTests.Add(test);
                }
            }
            BusinessLayerManager blManager= new BusinessLayerManager();
            List<BOCategory> categories=   blManager.GetAllCategories();
            TestReports reports = new TestReports(selectedTests, DateTime.Now, DateTime.Now, categories);
            reports.Show();
            this.Close();
            
        } 
    }
}
