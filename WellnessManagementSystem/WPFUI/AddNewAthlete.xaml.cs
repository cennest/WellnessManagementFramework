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
using PhysioApplication.Properties;
using BusinessLayer.Entities;
using BusinessLayer;
using System.Text.RegularExpressions;

namespace PhysioApplication
{
    /// <summary>
    /// Interaction logic for AddNewAthlete.xaml
    /// </summary>
    public partial class AddNewAthlete : Window
    {
        public AddNewAthlete()
        {
            InitializeComponent();
            AppManager appManager = AppManager.getInstance();
            appManager.CurrentWindow = this;
            BOUser userDetails = appManager.GetUserDetails();
            DataContext = userDetails;
            BusinessLayerManager businessLayer = new BusinessLayerManager();
            List<BOCategory> categoryList = businessLayer.GetAllCategories();
            List<ComboBoxItem> comboBoxItemList = new List<ComboBoxItem>();
            foreach (BOCategory category in categoryList)
            {
                comboBoxItemList.Add(new ComboBoxItem { Content = category.CategoryName, Tag = category.CategoryID.ToString() });
            }
            this.CategoryComboBox.ItemsSource = comboBoxItemList;
            this.CategoryComboBox.SelectedIndex = 0;
            SetBreadCrumb();
        }

        private void SetBreadCrumb()
        {
            List<string> headers = new List<string> { "Home","Settings","Add New Athlete" };
            ucBreadCrumb.ResetBreadCrumb(headers);
            ucBreadCrumb.CrumbSelected += ucBreadCrumb_CrumbSelected;
        }

        void ucBreadCrumb_CrumbSelected(string selectedString)
        {
            AppManager.getInstance().BreadCrumbSelected(selectedString);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool isPhoneNumberValid = IsValidTextNumber(txtPhone.Text);
                if (isPhoneNumberValid)
                {
                    
                }
                else
                {
                    MessageBox.Show("Please enter valid phone number");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void check_space(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Space)
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textbox_input(object sender, TextCompositionEventArgs e)
        {
            try
            {
                e.Handled = !IsValidTextNumber(e.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool IsValidTextNumber(string p)
        {
            try
            {
                return Regex.Match(p, "^[0-9]*$").Success;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
