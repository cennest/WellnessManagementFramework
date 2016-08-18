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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessLayer.Entities;
using BusinessLayer;
using PhysioApplication.GridPaging;
using PhysioApplication;

namespace PhysioApplication.UserControls
{
    /// <summary>
    /// Interaction logic for DietPlan.xaml
    /// </summary>
    public partial class DietPlan : UserControl
    {
        private readonly RoutedUICommand changedIndex;
        ObservableCollection<BODietPlan> currentDietPlanRecords;
        List<int> deletedDietPlanRecordIds;
        DateTime? fromSelectedDate;
        DateTime? toSelectedDate;
        public DietPlan()
        {
            InitializeComponent();
            this.changedIndex = new RoutedUICommand("ChangedIndex", "ChangedIndex", typeof(PhysicalConditioning));

            // Assing the command to GridPaging Command.
            gridPaging.ChangedIndexCommand = this.changedIndex;

            // Binding Command
            CommandBinding abinding = new CommandBinding { Command = this.changedIndex };

            // Binding Handler to executed.
            abinding.Executed += this.OnChangeIndexCommandHandler;
            this.CommandBindings.Add(abinding);
            LoadData();
            deletedDietPlanRecordIds = new List<int>();
            FromDate.SelectedDate = null;
            ToDate.SelectedDate = null;
        }

        private void LoadData()
        {
            gridPaging.ResetPageIndex();
            var pageIndex = gridPaging.PageIndex;
            var pageSize = gridPaging.PageSize;
            gridPaging.TotalCount = this.ExecuteQueryReturnTotalItem(pageIndex, pageSize);
        }

        private void OnChangeIndexCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            var pageIndex = gridPaging.PageIndex;
            var pageSize = gridPaging.PageSize;
            gridPaging.TotalCount = this.ExecuteQueryReturnTotalItem(pageIndex, pageSize);
        }

        private int ExecuteQueryReturnTotalItem(int pageIndex, int take)
        {
            int skip = ((pageIndex - 1) * take);
            int finalRow = skip + take;
            try
            {
                BusinessLayerManager businessLayer = new BusinessLayerManager();
                AppManager appManager = AppManager.getInstance();
                BOUser userDetails = appManager.GetUserDetails();
                List<BODietPlan>dietPlanRecords = businessLayer.GetDietPlanReportsWithinDates(userDetails.UserID, appManager.currentClientID, skip, take, fromSelectedDate, toSelectedDate);

                currentDietPlanRecords = new ObservableCollection<BODietPlan>(dietPlanRecords);
                dietPlanGrid.DataContext = currentDietPlanRecords;
                dietPlanGrid.ItemsSource = currentDietPlanRecords;
                return this.GetDietPlanReportsCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        private int GetDietPlanReportsCount()
        {
            try
            {
                BusinessLayerManager businessLayer = new BusinessLayerManager();
                AppManager appManager = AppManager.getInstance();
                BOUser userDetails = appManager.GetUserDetails();
                int dietPlanReportsCount = businessLayer.GetDietPlanReportsCount(userDetails.UserID, appManager.currentClientID, fromSelectedDate, toSelectedDate);
                return dietPlanReportsCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        private void FromDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fromSelectedDate = FromDate.SelectedDate;
            LoadData();
        }

        private void ToDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            toSelectedDate = ToDate.SelectedDate;
            LoadData();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            BODietPlan dietPlan = new BODietPlan();

            dietPlan.TestDate = DateTime.Now;
            currentDietPlanRecords.Insert(0, dietPlan);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int selectedItem = dietPlanGrid.SelectedIndex;
            if (currentDietPlanRecords.Count() > 0 && selectedItem >= 0)
            {
                BODietPlan deletedPhysicalConditionReport = currentDietPlanRecords.ElementAt(selectedItem);
                deletedDietPlanRecordIds.Add(deletedPhysicalConditionReport.DietPlanReportID);
                currentDietPlanRecords.RemoveAt(selectedItem);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BusinessLayerManager businessLayer = new BusinessLayerManager();
                List<BODietPlan> dietPlanList = currentDietPlanRecords.ToList();
                AppManager appmanager = AppManager.getInstance();
                BOUser user = appmanager.GetUserDetails();
                businessLayer.SaveDietPlanReportsForClient(deletedDietPlanRecordIds, dietPlanList, appmanager.currentClientID, user.UserID);
                MessageBox.Show("Save Successful");
                LoadData();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Records not Saved");
            }
        }
    }
}
