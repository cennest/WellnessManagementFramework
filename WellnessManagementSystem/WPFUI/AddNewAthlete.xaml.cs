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
        BOUser userDetails = new BOUser();
        string errorMsg = "";
        public AddNewAthlete()
        {
            InitializeComponent();
            AppManager appManager = AppManager.getInstance();
            appManager.CurrentWindow = this;
            userDetails = appManager.GetUserDetails();
            BusinessLayerManager businessLayer = new BusinessLayerManager();
            List<BOCategory> categoryList = businessLayer.GetAllCategories();
            List<ComboBoxItem> comboBoxItemList = new List<ComboBoxItem>();
            foreach (BOCategory category in categoryList)
            {
                comboBoxItemList.Add(new ComboBoxItem { Content = category.CategoryName, Tag = category.CategoryID.ToString() });
            }
            this.CategoryComboBox.ItemsSource = comboBoxItemList;
            this.CategoryComboBox.SelectedIndex = 0;
            SetLogOut();
            SetBreadCrumb();
        }

        private void SetLogOut()
        {
            this.ucLogoutUC.OnLogout += new EventHandler(ucLogoutUC_OnLogout);
        }

        public void ucLogoutUC_OnLogout(object sender, EventArgs e)
        {
            AppManager.getInstance().LogOut();

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
                bool isDataValid = IsDataValid();
                if (isDataValid)
                {
                    string clientName = txtName.Text;
                    long phone = Convert.ToInt64(txtPhone.Text);
                    string address = txtAddress.Text;
                    int userID = userDetails.UserID;
                    int CategoryID = Convert.ToInt32(((ComboBoxItem)CategoryComboBox.SelectedItem).Tag);
                    BusinessLayerManager businessLayer = new BusinessLayerManager();
                    bool isClientAdded = businessLayer.AddClient(clientName, phone, address, userID, CategoryID);
                    if (isClientAdded == true)
                    {
                        MessageBox.Show("Athlete added successfully!");
                        txtName.Text = "";
                        txtPhone.Text = "";
                        txtAddress.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Failed to add New Athelete!");
                    }
                }
                else
                {
                    MessageBox.Show(errorMsg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool IsDataValid()
        {
            bool isPhoneNumberValid = IsValidTextNumber(txtPhone.Text);

            if (txtName.Text == "")
            {
                errorMsg = "Please enter Athlete Name";
                return false;
            }
            if (txtPhone.Text == "")
            {
                errorMsg = "Please enter phone number";
                return false;
            }
            if (isPhoneNumberValid == false)
            {
                errorMsg = "Please enter correct phone number";
                return false;
            }
            if (txtAddress.Text == "")
            {
                errorMsg = "Please enter Address";
                return false;
            }
            return true;
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
