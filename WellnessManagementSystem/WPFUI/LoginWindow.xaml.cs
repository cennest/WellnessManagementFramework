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
using System.Windows.Navigation;
using System.IO.IsolatedStorage;
using System.IO;

namespace PhysioApplication
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public static string fileName = "isoFile";

        public LoginWindow()
        {
            InitializeComponent();

            AppManager appManager = AppManager.getInstance();
            appManager.CurrentWindow=this;
            GetLoginCredentialFromStorageFile(); 
        }

        private void GetLoginCredentialFromStorageFile()
        {
            try
            {
                IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly();
                StreamReader reader = new StreamReader(new IsolatedStorageFileStream(fileName, FileMode.OpenOrCreate, isolatedStorage));
                if (reader != null)
                {
                    while (!reader.EndOfStream)
                    {
                        string userName = reader.ReadLine();
                        UserName.Text = userName;
                        string password = reader.ReadLine();
                        Password.Password = password;
                    }
                }
                reader.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(ResourceConstants.InvalidUserNameOrPassword);
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveLoginCredentialInStorageFile();
                ValidateUserCredentials();
            }
            catch (Exception exception)
            {
                MessageBox.Show(ResourceConstants.InvalidUserNameOrPassword);
            }
        }

        private void SaveLoginCredentialInStorageFile()
        {
            if (RMCheckBox.IsChecked == true)
            {
                string userName = UserName.Text.Trim().ToString();
                string password = Password.Password.Trim().ToString();
                if ((userName != null && password != null) && (userName != "" && password != ""))
                {
                    IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly();
                    StreamWriter srWriter = new StreamWriter(new IsolatedStorageFileStream(fileName, FileMode.Create, isolatedStorage));
                    srWriter.WriteLine(userName);
                    srWriter.WriteLine(password);
                    srWriter.Flush();
                    srWriter.Close();
                }
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                SaveLoginCredentialInStorageFile();
                ValidateUserCredentials();
            }
        }

        private void ValidateUserCredentials()
        {
            BusinessLayerManager businessLayer = new BusinessLayerManager();
            BOUser userDetails = businessLayer.GetUser(UserName.Text, Password.Password);
            if (userDetails == null)
            {
                MessageBox.Show(ResourceConstants.InvalidUserNameOrPassword);
            }
            else
            {
                AppManager appManager = AppManager.getInstance();
                appManager.SetUserDetails(userDetails);
                Dictionary<string, List<BOUserField>> userReportFields = businessLayer.GetReportFieldsForUser(userDetails.UserID);
                foreach (KeyValuePair<string, List<BOUserField>> keyValuePair in userReportFields)
                {
                    if (keyValuePair.Key == "LabReport")
                    {
                        appManager.SetLabReportFieldsForUser(keyValuePair.Value);
                    }
                }

                
                HomePage homePage = new HomePage();                
                homePage.Show();
                this.Close();
            }
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Return)
            {
                SaveLoginCredentialInStorageFile();
                ValidateUserCredentials();
            }
        }
    }
    public class WaterMarkTextHelper : DependencyObject
    {
        public static bool GetIsMonitoring(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsMonitoringProperty);
        }
        public static void SetIsMonitoring(DependencyObject obj, bool value)
        {
            obj.SetValue(IsMonitoringProperty, value);
        }
        public static readonly DependencyProperty IsMonitoringProperty =
           DependencyProperty.RegisterAttached("IsMonitoring", typeof(bool), typeof(WaterMarkTextHelper), new UIPropertyMetadata(false, OnIsMonitoringChanged));
        public static int GetTextLength(DependencyObject obj)
        {
            return (int)obj.GetValue(TextLengthProperty);
        }
        public static void SetTextLength(DependencyObject obj, int value)
        {
            obj.SetValue(TextLengthProperty, value); 
            if (value >= 1)
                obj.SetValue(HasTextProperty, true); 
            else 
                obj.SetValue(HasTextProperty, false);
        }
        public static readonly DependencyProperty TextLengthProperty =
           DependencyProperty.RegisterAttached("TextLength", typeof(int), typeof(WaterMarkTextHelper), new UIPropertyMetadata(0));
        private static readonly DependencyProperty HasTextProperty =
            DependencyProperty.RegisterAttached("HasText", typeof(bool), typeof(WaterMarkTextHelper), new FrameworkPropertyMetadata(false));
        public bool HasText
        {
            get { return (bool)GetValue(HasTextProperty); }
            set { SetValue(HasTextProperty, value); }
        }
        private static void OnIsMonitoringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox)
            {
                TextBox txtBox = d as TextBox; 
                if ((bool)e.NewValue)
                    txtBox.TextChanged += TextChanged; 
                else 
                    txtBox.TextChanged -= TextChanged;
            }
            else if (d is PasswordBox)
            {
                PasswordBox passBox = d as PasswordBox;
                if ((bool)e.NewValue)
                    passBox.PasswordChanged += PasswordChanged; 
                else 
                    passBox.PasswordChanged -= PasswordChanged;
            }
        }
        static void TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox; 
            if (txtBox == null) 
                return;
            SetTextLength(txtBox, txtBox.Text.Length);
        }
        static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passBox = sender as PasswordBox; 
            if (passBox == null)
                return;
            SetTextLength(passBox, passBox.Password.Length);
        }
    }
}
