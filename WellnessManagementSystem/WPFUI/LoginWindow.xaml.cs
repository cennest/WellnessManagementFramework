﻿using System;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                BusinessLayerManager businessLayer = new BusinessLayerManager();
                UserDetails userDetails = businessLayer.GetUser(UserName.Text, Password.Text);
                if (userDetails == null)
                    MessageBox.Show(ResourceConstants.InvalidUserNameOrPassword);
                else
                    MessageBox.Show(ResourceConstants.LoginSuccessful);
            }
            catch(Exception )
            {
                MessageBox.Show(ResourceConstants.InvalidUserNameOrPassword);
            }
        }
        private void UserNameTextBox_click(object sender, RoutedEventArgs e)
        {
            if (UserName.Text == ResourceConstants.EnterUserName)
            {
                UserName.Text = "";
            }
        }
        private void PasswordTextBox_click(object sender, RoutedEventArgs e)
        {
            if (UserName.Text == "")
            {
                UserName.Text = ResourceConstants.EnterUserName;
            }
            if (Password.Text == ResourceConstants.EnterPassword)
            {
                Password.Text = "";
            }
        }

        private void checkEmptyFields()
        {
             if(UserName.Text == "")
            {
                UserName.Text = ResourceConstants.EnterUserName;
            }
            if (Password.Text == "")
            {
             Password.Text = ResourceConstants.EnterPassword;
            }
        }

        private void UserName_LostFocus(object sender, RoutedEventArgs e)
        {
            checkEmptyFields();
        }

        private void Password_LostFocus(object sender, RoutedEventArgs e)
        {
            checkEmptyFields();
        }

    }
}
