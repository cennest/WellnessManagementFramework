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
using BusinessLayer;
using BusinessLayer.Entities;

namespace PhysioApplication
{
    /// <summary>
    /// Interaction logic for AddNewTest.xaml
    /// </summary>
    public partial class AddNewTest : Window
    {
        public delegate void TestAddedEventHandler(int testID,string testName);
        public event TestAddedEventHandler testAdded;
        public AddNewTest()
        {
            InitializeComponent();
        }

        private void AddTest_Click(object sender, RoutedEventArgs e)
        {
            string testName = TestNameTextBox.Text;
            if (testName == "")
            {
                MessageBox.Show("Enter Test Name");
            }
            else
            {
                AppManager appManager=AppManager.getInstance();
                BOUser userDetails=appManager.GetUserDetails();
                BusinessLayerManager businessLayer=new BusinessLayerManager();
                int testID = businessLayer.SaveTestForUser(userDetails.UserID,testName);
                if (testID > 0)
                {
                    MessageBox.Show("Save Sucessful");
                    this.testAdded(testID,testName);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Save Unsuccessful");
                }
              
            }
        }
    }
}
