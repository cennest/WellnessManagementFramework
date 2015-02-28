using BusinessLayer.Entities;
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

namespace PhysioApplication.UserControls
{
    /// <summary>
    /// Interaction logic for Logout.xaml
    /// </summary>
    public partial class Logout : UserControl
    {
        public event EventHandler OnLogout;
        public Logout()
        {
            InitializeComponent();
            AppManager appManager = AppManager.getInstance();
            BOUser userDetails = appManager.GetUserDetails();
            DataContext = userDetails;
           
        }        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?",
                "Log Out", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (OnLogout != null)
                {
                    OnLogout(this, new EventArgs());
                }
            }
        }
    }
}
