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

namespace PhysioApplication
{
    /// <summary>
    /// Interaction logic for HistoricalTrends.xaml
    /// </summary>
    public partial class HistoricalTrends : Window
    {
        List<int> listOfCategories;
        List<int> listOfTests;
        DateTime? fromSelectedDate;
        DateTime? toSelectedDate;
        public HistoricalTrends()
        {
            InitializeComponent();
            AppManager appManager = AppManager.getInstance();
            appManager.CurrentWindow = this;
            SetBreadCrumb();
            LoadControls();
        }

        private void LoadControls()
        {
            BusinessLayerManager businessLayer = new BusinessLayerManager();
            cbCategories.ItemsSource = AppManager.getInstance().CurrentCategories;

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
            List<string> headers = new List<string> { "Home", "Settings", "Historical Trends" };
            ucBreadCrumb.ResetBreadCrumb(headers);
            ucBreadCrumb.CrumbSelected += ucBreadCrumb_CrumbSelected;
        }

        void ucBreadCrumb_CrumbSelected(string selectedString)
        {
            AppManager.getInstance().BreadCrumbSelected(selectedString);
        }
    }
}
