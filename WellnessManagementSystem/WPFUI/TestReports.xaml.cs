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
using BusinessLayer.Entities;

namespace PhysioApplication
{
    /// <summary>
    /// Interaction logic for TestReports.xaml
    /// </summary>
    public partial class TestReports : Window
    {
        List<BOCategory> categoriesSelected;
        List<BOLabTest> testsSelected;
        DateTime fromDate;
        DateTime toDate;
        BOCategory selectedCategory;
        public TestReports()
        {
            InitializeComponent();
            AppManager appManager = AppManager.getInstance();
            appManager.CurrentWindow = this;
        }
        public TestReports(List<BOLabTest>boTests,DateTime from, DateTime to, List<BOCategory> categories)
        {
            InitializeComponent();

            AppManager appManager = AppManager.getInstance();
            appManager.CurrentWindow = this;


            categoriesSelected = categories;
            selectedCategory = categoriesSelected[0];
            testsSelected = boTests;
            fromDate = from;
            toDate = to;
            foreach (BOLabTest test in boTests)
            {
                TabItem tab = new TabItem();
                tab.DataContext = test;
                tab.Header = test.LabTest;
                tab.Tag = test.LabTestID;
                reportsTab.Items.Add(tab);
            }
        }

        private void reportsTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected =(TabItem) reportsTab.SelectedItem;
            int testID = int.Parse(selected.Tag.ToString());
            BusinessLayer.BusinessLayerManager blManager = new BusinessLayer.BusinessLayerManager();
          var lists=  blManager.GetDataForCategoryLevelReport(AppManager.getInstance().GetUserDetails().UserID, testID, DateTime.Now, DateTime.Now, selectedCategory.CategoryID);
        }
    }
}
