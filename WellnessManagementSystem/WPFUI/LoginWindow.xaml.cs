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
//using BusinessLayer;
namespace PhysioApplication
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        //    BusinessLayerManager businessLayer = new BusinessLayerManager();
        //    bool authenticationSuccessful=businessLayer.GetUser(UserName.Text,Password.Text);
        //    if (authenticationSuccessful == true)
        //    {
        //        MessageBox.Show("Authentication Successful");
            Window1 nextWindow = new Window1();
            nextWindow.Show();
            //this.Close();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Authentication Failed");
        //    }
        }
    }
}
