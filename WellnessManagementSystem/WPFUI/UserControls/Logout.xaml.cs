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

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (OnLogout != null)
            {
                OnLogout(this, new EventArgs());
            }
        }

        private void Run_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
           
        }
    }
}
