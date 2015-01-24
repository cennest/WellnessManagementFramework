using BusinessLayer.Entities;
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
using System.Collections;

namespace PhysioApplication
{
    /// <summary>
    /// Interaction logic for Reporting.xaml
    /// </summary>
    public partial class Reporting : Window
    {
        private int categoryID;
        private int reportID;

        public Reporting()
        {
            InitializeComponent();
            BusinessLayerManager businessLayer = new BusinessLayerManager();
            List<BOCategory> categoryList = businessLayer.GetAllCategories();
            List<ComboBoxItem> comboBoxItemListForCategory = new List<ComboBoxItem>();
            foreach (BOCategory category in categoryList)
            {
                comboBoxItemListForCategory.Add(new ComboBoxItem { Content = category.CategoryName, Tag = category.CategoryID.ToString() });
            }
            this.ComboBoxForCategory.ItemsSource = comboBoxItemListForCategory;
            this.ComboBoxForCategory.SelectedIndex = 0;

            List<BOReporting> reportList = businessLayer.GetAllReports();
            List<ComboBoxItem> comboBoxItemListForTest = new List<ComboBoxItem>();
            foreach (BOReporting report in reportList)
            {
                comboBoxItemListForTest.Add(new ComboBoxItem { Content = report.ReportFieldName, Tag = report.ReportFieldID.ToString() });
            }
            this.ComboBoxForTest.ItemsSource = comboBoxItemListForTest;
            this.ComboBoxForTest.SelectedIndex = 0;

            this.categoryID = Convert.ToInt32(((ComboBoxItem)ComboBoxForCategory.SelectedItem).Tag);
            BOUser userDetail =  AppManager.getInstance().GetUserDetails();
            int userID = 1;
            List<BOClient> clientList = businessLayer.GetClientsForCategories(categoryID, userID);
            List<ComboBoxItem> comboBoxItemListForClient = new List<ComboBoxItem>();
            foreach (BOClient client in clientList)
            {
                comboBoxItemListForClient.Add(new ComboBoxItem { Content = client.ClientName, Tag = client.ClientID.ToString() });
            }
            this.ComboBoxForClient.ItemsSource = comboBoxItemListForClient;
            this.ComboBoxForClient.SelectedIndex = 0;

            LoadFirstSeries();
        }


        private void LoadLineChartData()
        {
            //if (this.categoryID != 0 && this.reportID != 0)
            //{
            //    BusinessLayerManager businessLayer = new BusinessLayerManager();
            //    Hashtable listOfReportForCategoryHasTable = businessLayer.GetLabReportsForCategory(this.categoryID, 1, this.reportID);
            //    foreach (DictionaryEntry entry in listOfReportForCategoryHasTable)
            //    {
            //        Console.WriteLine("{0}, {1}", entry.Key, entry.Value);
            //        List<BOLabReport> labReportList = (List<BOLabReport>)listOfReportForCategoryHasTable[entry.Key];
            //        List<KeyValuePair<DateTime, int>> keyValuePair = new List<KeyValuePair<DateTime, int>>();
            //        foreach (BOLabReport labReport in labReportList)
            //        {
            //            keyValuePair.Add(new KeyValuePair<DateTime, int>(labReport.TestDate, Convert.ToInt32(labReport.ReportFieldValue)));
            //        }
            //        // ((LineSeries)mcChart.Series[0]).ItemsSource = keyValuePair;
            //    }
                //((LineSeries)mcChart.Series[0]).ItemsSource =
                // new KeyValuePair<DateTime, int>[]{
                //new KeyValuePair<DateTime, int>(DateTime.Now, 100),
                //new KeyValuePair<DateTime, int>(DateTime.Now.AddMonths(1), 130),
                //new KeyValuePair<DateTime, int>(DateTime.Now.AddMonths(2), 150),
                //new KeyValuePair<DateTime, int>(DateTime.Now.AddMonths(3), 125),
                //new KeyValuePair<DateTime, int>(DateTime.Now.AddMonths(4), 155) };
            //}
        }
        //private void FilterComboBoxForCategorySelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        //{
        //    ComboBox categoryComboBox = (ComboBox)sender;
        //    ComboBoxItem item = (ComboBoxItem)categoryComboBox.SelectedItem;
        //    this.categoryID = Convert.ToInt32(item.Tag);
        //    LoadLineChartData();
        //}
        //private void FilterComboBoxForTestsSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        //{
        //    ComboBox reportComboBox = (ComboBox)sender;
        //    ComboBoxItem item = (ComboBoxItem)reportComboBox.SelectedItem;
        //    this.reportID = Convert.ToInt32(item.Tag);
        //    LoadLineChartData();
        //}

        private void LoadFirstSeries()
        {
            List<KeyValuePair<string, int>> valueList = new List<KeyValuePair<string, int>>();
            valueList.Add(new KeyValuePair<string, int>("Client1", 20));
            valueList.Add(new KeyValuePair<string, int>("Client2", 25));
            valueList.Add(new KeyValuePair<string, int>("Client2", 40));
            valueList.Add(new KeyValuePair<string, int>("Client4", 50));
            valueList.Add(new KeyValuePair<string, int>("Client5", 60));

            firstSeries.Visibility = Visibility.Visible;
            secondSeries.Visibility = Visibility.Hidden;

            lineChart.DataContext = valueList;
        }

        private void LoadSecondSeries()
        {
            List<KeyValuePair<string, int>> valueList = new List<KeyValuePair<string, int>>();
            valueList.Add(new KeyValuePair<string, int>("Client1", 60));
            valueList.Add(new KeyValuePair<string, int>("Client2", 20));
            valueList.Add(new KeyValuePair<string, int>("Client3", 50));
            valueList.Add(new KeyValuePair<string, int>("Client4", 30));
            valueList.Add(new KeyValuePair<string, int>("Client5", 40));
            secondSeries.Visibility = Visibility.Visible;
            firstSeries.Visibility = Visibility.Hidden;
            lineChart.DataContext = valueList;
        }

        private void Chart_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LoadSecondSeries();
        }

        private void FilterComboBoxSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                BusinessLayerManager businessLayer = new BusinessLayerManager();
                this.categoryID = Convert.ToInt32(((ComboBoxItem)ComboBoxForCategory.SelectedItem).Tag);
                BOUser userDetail = AppManager.getInstance().GetUserDetails();
                int userID = 1;
                List<BOClient> clientList = businessLayer.GetClientsForCategories(categoryID, userID);
                List<ComboBoxItem> comboBoxItemListForClient = new List<ComboBoxItem>();
                foreach (BOClient client in clientList)
                {
                    comboBoxItemListForClient.Add(new ComboBoxItem { Content = client.ClientName, Tag = client.ClientID.ToString() });
                }
                this.ComboBoxForClient.ItemsSource = comboBoxItemListForClient;
                this.ComboBoxForClient.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
