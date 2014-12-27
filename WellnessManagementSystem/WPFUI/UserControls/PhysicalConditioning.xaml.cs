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

namespace PhysioApplication.UserControls
{
    /// <summary>
    /// Interaction logic for PhysicalConditioning.xaml
    /// </summary>
    public partial class PhysicalConditioning : UserControl
    {
        ObservableCollection<BOPhysicalCondition> currentphysicalConditionRecords;

        public PhysicalConditioning()
        {
            InitializeComponent();
            BusinessLayerManager businessLayer = new BusinessLayerManager();
            List<BOPhysicalCondition> physicalConditionRecords = businessLayer.GetPhysicalConditioningReportsForCategoryByName(1, 1, 1, "ABC", null, null, 10, 10);
           currentphysicalConditionRecords=new ObservableCollection<BOPhysicalCondition>(physicalConditionRecords);
           physicalConditionGrid.DataContext = currentphysicalConditionRecords;
           physicalConditionGrid.ItemsSource = currentphysicalConditionRecords;
            

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int selectedItem = physicalConditionGrid.SelectedIndex;
            if (selectedItem >= 0)
            {
                currentphysicalConditionRecords.RemoveAt(selectedItem);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            BOPhysicalCondition physicalCondition = new BOPhysicalCondition();

            physicalCondition.TestDate = DateTime.Now;
            currentphysicalConditionRecords.Insert(0, physicalCondition);
        }

        private void ToDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FromDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            List<BOPhysicalCondition> physicalConditionList = currentphysicalConditionRecords.ToList();
        }
    }
}
