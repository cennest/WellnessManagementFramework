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

namespace PhysioApplication
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
        }

        public HomePage(UserDetails userDetails)
        {
            if (userDetails != null)
            {
                AppManager appManager = AppManager.getInstance();
                appManager.setUserID(userDetails.UserID);
                appManager.SetUserName(userDetails.UserName);
                DataContext = appManager;
            }
        }
    }
}
