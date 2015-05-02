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
using System.Windows.Controls.DataVisualization.Charting;

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
        List<KeyValuePair<int, DateTime>> keyValuePair;
        Random random = new Random();
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
            keyValuePair = new List<KeyValuePair<int, DateTime>>();
            TabItem selectedTab = (TabItem)reportsTab.SelectedItem;
            int testID = int.Parse(selectedTab.Tag.ToString());
            BusinessLayer.BusinessLayerManager blManager = new BusinessLayer.BusinessLayerManager();
            var lists = blManager.GetDataForCategoryLevelReport(AppManager.getInstance().GetUserDetails().UserID, testID, DateTime.Now, DateTime.Now, selectedCategory.CategoryID);
            Chart chart = new Chart();
            foreach (List<KeyValuePair<DateTime, float>> valueList in lists)
            {
                List<KeyValuePair<int, float>> seriesList = new List<KeyValuePair<int, float>>();
                foreach (KeyValuePair<DateTime, float> keyValue in valueList)
                {
                    KeyValuePair<int, float> kv = new KeyValuePair<int, float>(((DateTime)keyValue.Key).Month, keyValue.Value);
                    seriesList.Add(kv);
                }
                foreach (KeyValuePair<DateTime, float> keyValue in valueList)
                {
                    KeyValuePair<int, DateTime> kv = new KeyValuePair<int, DateTime>(((DateTime)keyValue.Key).Month, ((DateTime)keyValue.Key));
                    keyValuePair.Add(kv);
                }
                if (valueList.Count > 0)
                {
                    LineSeries series = new LineSeries();

                    Style style = this.FindResource("lineSeriesStyle") as Style;
                    Style customStyle = new Style(typeof(LineDataPoint), style);
                    Color background = Color.FromRgb((byte)random.Next(255),(byte)random.Next(255),(byte)random.Next(255));
                    customStyle.Setters.Add(new Setter(Label.BackgroundProperty, new SolidColorBrush(background)));
                    series.DataPointStyle = customStyle;
                    series.DependentValuePath = "Value";
                    series.IndependentValuePath = "Key";
                    series.ItemsSource = seriesList;
                    series.DataContext = seriesList;
                    //series.Title = "data";
                    chart.Series.Add(series);
                }
            }
            LinearAxis linearAxis = new LinearAxis();
            linearAxis.Orientation = AxisOrientation.X;
            linearAxis.Minimum = 1;
            linearAxis.Maximum = 12;
            linearAxis.Interval = 1;
            chart.Axes.Add(linearAxis);
            selectedTab.Content = chart;
            reportsTab.SelectedItem = selectedTab;
        }

        private void ContentControl_Initialized(object sender, EventArgs e)
        {
            ContentControl cc = (ContentControl)sender;
            int key = (int)cc.Tag;
            List<DateTime> dtList = new List<DateTime>();
            foreach (KeyValuePair<int, DateTime> keyValue in keyValuePair)
            {
                if((int)keyValue.Key == key)
                {
                    dtList.Add(keyValue.Value);
                }
            }
            //dtList.Sort();
            cc.Content = dtList.LastOrDefault();
            KeyValuePair<int, DateTime> kvalue = new KeyValuePair<int, DateTime>(key, dtList.LastOrDefault());
            keyValuePair.Remove(kvalue);
        }
    }
}
