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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessLayer.Entities;
using BusinessLayer;

namespace PhysioApplication.UserControls
{
    /// <summary>
    /// Interaction logic for FilterUC.xaml
    /// </summary>
    public partial class FilterUC : UserControl
    {
        BusinessLayerManager businessLayer = new BusinessLayerManager();
        public delegate void OptionChangedEventHandler(bool isSearchByName,string name);
        public event OptionChangedEventHandler OptionChanged;

        public FilterUC()
        {
            InitializeComponent();
            List<BOCategory> categoryList = businessLayer.GetAllCategories();
            List<ComboBoxItem> comboBoxItemList = new List<ComboBoxItem>();
            foreach (BOCategory category in categoryList)
            {
                comboBoxItemList.Add(new ComboBoxItem { Content = category.CategoryName, Tag = category.CategoryID.ToString() });
            }
            this.cbPageFilter.ItemsSource = comboBoxItemList;
            this.cbPageFilter.SelectedIndex = 0;
        }

        private void FilterComboBoxSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.OptionChanged != null)
            {
                this.OptionChanged(false,"");
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.OptionChanged != null)
            {
                this.OptionChanged(true,this.SearchTextBlock.Text);
            }
        }
    }
}
