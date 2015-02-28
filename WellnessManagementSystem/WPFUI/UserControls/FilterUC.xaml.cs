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
            LoadCategories();
         
        }

        private void LoadCategories()
        {
            var appManagerCategories = AppManager.getInstance().CurrentCategories;
          
            List<ComboBoxItem> comboBoxItemList = new List<ComboBoxItem>();

            

            int firstIndex = 0;
            comboBoxItemList.Add(new ComboBoxItem { Content = "All Sports", Tag = firstIndex.ToString() });
            foreach (BOCategory category in appManagerCategories)
            {
                comboBoxItemList.Add(new ComboBoxItem { Content = category.CategoryName, Tag = category.CategoryID.ToString() });
            }
            this.ComboBoxPageFilter.ItemsSource = comboBoxItemList;
            this.ComboBoxPageFilter.SelectedIndex = firstIndex;
        }

        private void FilterComboBoxSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this.SearchTextBlock.Text = "";
            bool isSearchByName = false;
            this.SearchData(isSearchByName, "");
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            bool isSearchByName = true;
            string name = this.SearchTextBlock.Text;
            this.SearchData(isSearchByName, name);
        }

        private void Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                bool isSearchByName = true;
                string name = this.SearchTextBlock.Text;
                this.SearchData(isSearchByName, name);
            }
        }

        private void SearchData(bool isSearchByName, string name)
        {
            if (this.OptionChanged != null)
            {
                this.OptionChanged(isSearchByName, name);
            }
        }
    }
}
