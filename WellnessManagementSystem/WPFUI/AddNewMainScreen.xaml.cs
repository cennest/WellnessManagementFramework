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
using System.Data;
using PhysioApplication.Properties;
using BusinessLayer.Entities;
using System.Reflection;

namespace PhysioApplication
{
    /// <summary>
    /// Interaction logic for AddNewMainScreen.xaml
    /// </summary>
    public partial class AddNewMainScreen : Window
    {
        public const string NO_OF_ADD_BUTTONS = "NoOfAddButtons";
        public const string BUTTON_TEXT = "AddNewButton";
        public const string BUTTON_TITLE_TEXT = "Title";
        public const string COLUMN_NAME_BUTTONS = "ButtonsList";
        public AddNewMainScreen()
        {
            InitializeComponent();
            AppManager appManager = AppManager.getInstance();

            appManager.CurrentWindow = this;
            BOUser userDetails = appManager.GetUserDetails();
            DataContext = userDetails;
            InitializeCustomComponents();
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
        public void InitializeCustomComponents()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn(COLUMN_NAME_BUTTONS, Type.GetType("PhysioApplication.ButtonsList")));
       
            System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager("PhysioApplication.Properties.Resources", Assembly.GetExecutingAssembly());
            int noOfButtons = Convert.ToInt32(resourceManager.GetString(NO_OF_ADD_BUTTONS));
            for (int i = 1; i < noOfButtons + 1; i++)
            {                                                                                                                                                                                                                           
                string buttonTitle = resourceManager.GetString(BUTTON_TEXT + i + BUTTON_TITLE_TEXT);
                dataTable.Rows.Add(new ButtonsList { Content = buttonTitle, ToolTip = buttonTitle });
            }
            dtGrid.ItemsSource = dataTable.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string buttonTitle = button.Content.ToString();
            if (buttonTitle == "Add New Athlete")
            {
                AddNewAthlete addNewAthlete = new AddNewAthlete();
                addNewAthlete.Show();
            }
            else if (buttonTitle == "View Tests")
            {
                LabTestsScreen labTestScreen = new LabTestsScreen();
                labTestScreen.Show();
            }
            this.Close();
        }
        private void SetBreadCrumb()
        {
            List<string> headers = new List<string> { "Home", "Settings" };
            ucBreadCrumb.ResetBreadCrumb(headers);
            ucBreadCrumb.CrumbSelected += ucBreadCrumb_CrumbSelected;
        }

        private void ucBreadCrumb_CrumbSelected(string selectedString)
        {
            AppManager.getInstance().BreadCrumbSelected(selectedString);
        }
    }
}
