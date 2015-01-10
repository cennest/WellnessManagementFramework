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
    /// Interaction logic for PhysicalConditioning.xaml
    /// </summary>
    public partial class PhysicalConditioning : UserControl
    {
        private readonly RoutedUICommand changedIndex;
        ObservableCollection<BOPhysicalConditionReport> currentphysicalConditionRecords;
        List<int> deletedPhysicalConditionRecordIds;
        DateTime? fromSelectedDate;
        DateTime? toSelectedDate;

        public PhysicalConditioning()
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
           deletedPhysicalConditionRecordIds = new List<int>();
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

        private int GetPhysicalConditioningReportsCount()
        {
            try
            {
                BusinessLayerManager businessLayer = new BusinessLayerManager();
                AppManager appManager = AppManager.getInstance();
                BOUser userDetails = appManager.GetUserDetails();
                int physicalConditioningReportsCount = businessLayer.GetPhysicalConditioningReportsCount(userDetails.UserID, appManager.currentClientID,fromSelectedDate,toSelectedDate);
                return physicalConditioningReportsCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        private void OnChangeIndexCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            var pageIndex = gridPaging.PageIndex;
            var pageSize = gridPaging.PageSize;
            gridPaging.TotalCount = this.ExecuteQueryReturnTotalItem(pageIndex,pageSize);
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
                List<BOPhysicalConditionReport> physicalConditionRecords = businessLayer.GetPhysicalConditioningReportsWithinDates(userDetails.UserID, appManager.currentClientID, skip,take, fromSelectedDate,toSelectedDate);
                currentphysicalConditionRecords = new ObservableCollection<BOPhysicalConditionReport>(physicalConditionRecords);
                physicalConditionGrid.DataContext = currentphysicalConditionRecords;
                physicalConditionGrid.ItemsSource = currentphysicalConditionRecords;
                return this.GetPhysicalConditioningReportsCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int selectedItem = physicalConditionGrid.SelectedIndex;
            if (currentphysicalConditionRecords.Count() > 0 && selectedItem >= 0)
            {
               BOPhysicalConditionReport deletedPhysicalConditionReport= currentphysicalConditionRecords.ElementAt(selectedItem);
               deletedPhysicalConditionRecordIds.Add(deletedPhysicalConditionReport.PhysicalConditionID);
               currentphysicalConditionRecords.RemoveAt(selectedItem);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            BOPhysicalConditionReport physicalCondition = new BOPhysicalConditionReport();

            physicalCondition.TestDate = DateTime.Now;
            currentphysicalConditionRecords.Insert(0, physicalCondition);
        }

        private void ToDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            toSelectedDate = ToDate.SelectedDate;
            LoadData();
          
        }

        private void FromDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fromSelectedDate = FromDate.SelectedDate;
            LoadData();
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BusinessLayerManager businessLayer = new BusinessLayerManager();
                List<BOPhysicalConditionReport> physicalConditionList = currentphysicalConditionRecords.ToList();
                AppManager appmanager = AppManager.getInstance();
                BOUser user = appmanager.GetUserDetails();
                businessLayer.SavePhysicalConditionReportsForClient(deletedPhysicalConditionRecordIds, physicalConditionList, appmanager.currentClientID, user.UserID);
                MessageBox.Show("Save Successful");
                LoadData();
            }
            catch(Exception exception)
            {
                MessageBox.Show("Records not Saved");
            }
          
        }
    }
}
