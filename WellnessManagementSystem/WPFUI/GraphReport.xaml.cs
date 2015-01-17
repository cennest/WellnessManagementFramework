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
using System.Windows.Controls.DataVisualization;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.DataVisualization.Charting;
using BusinessLayer.Entities;
using BusinessLayer;
using System.Collections;

namespace PhysioApplication
{
    /// <summary>
    /// Interaction logic for GraphReport.xaml
    /// </summary>
    public partial class GraphReport : Window
    {
        private int categoryID;
        private int reportID;

        public GraphReport()
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

            List<BOReportFieldMaster> reportList = businessLayer.GetAllReports();
            List<ComboBoxItem> comboBoxItemListForReport = new List<ComboBoxItem>();
            foreach (BOReportFieldMaster report in reportList)
            {
                comboBoxItemListForReport.Add(new ComboBoxItem { Content = report.ReportFieldName, Tag = report.ReportFieldID.ToString() });
            }
            this.ComboBoxForReport.ItemsSource = comboBoxItemListForReport;
            this.ComboBoxForReport.SelectedIndex = 0;
        }

        private void LoadLineChartData()
        {
            if (this.categoryID != 0 && this.reportID != 0)
            {
                BusinessLayerManager businessLayer = new BusinessLayerManager();
                Hashtable listOfReportForCategoryHasTable = businessLayer.GetLabReportsForCategory(this.categoryID, 1, this.reportID);

                foreach (DictionaryEntry entry in listOfReportForCategoryHasTable)
                {
                    Console.WriteLine("{0}, {1}", entry.Key, entry.Value);
                    List<BOLabReport> labReportList = (List<BOLabReport>)listOfReportForCategoryHasTable[entry.Key];
                    List<KeyValuePair<DateTime, int>> keyValuePair = new List<KeyValuePair<DateTime, int>>();
                    foreach (BOLabReport labReport in labReportList)
                    {
                        keyValuePair.Add(new KeyValuePair<DateTime, int>(labReport.TestDate, Convert.ToInt32(labReport.ReportFieldValue)));
                    }
                    ((LineSeries)mcChart.Series[0]).ItemsSource = keyValuePair;
                }
               
                //((LineSeries)mcChart.Series[0]).ItemsSource =
                //    new KeyValuePair<DateTime, int>[]{
                //new KeyValuePair<DateTime, int>(DateTime.Now, 100),
                //new KeyValuePair<DateTime, int>(DateTime.Now.AddMonths(1), 130),
                //new KeyValuePair<DateTime, int>(DateTime.Now.AddMonths(2), 150),
                //new KeyValuePair<DateTime, int>(DateTime.Now.AddMonths(3), 125),
                //new KeyValuePair<DateTime, int>(DateTime.Now.AddMonths(4), 155) };
            }
        }

        private void FilterComboBoxForCategorySelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBox categoryComboBox = (ComboBox)sender;
            ComboBoxItem item= (ComboBoxItem)categoryComboBox.SelectedItem;
            this.categoryID = Convert.ToInt32(item.Tag);
            LoadLineChartData();
        }

        private void FilterComboBoxForTestsSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBox reportComboBox = (ComboBox)sender;
            ComboBoxItem item = (ComboBoxItem)reportComboBox.SelectedItem;
            this.reportID = Convert.ToInt32(item.Tag);
            LoadLineChartData();
        }
    }
}
