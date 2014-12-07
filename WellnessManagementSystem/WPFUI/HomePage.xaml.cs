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
using PhysioApplication.Properties;
using BusinessLayer.Entities;
using System.Data;
using System.Reflection;

namespace PhysioApplication
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public const string NO_OF_BUTTONS = "NoOfButtons";
        public const string BUTTON_TEXT = "Button";
        public const string BUTTON_DESCRIPTION_TEXT = "Description";
        public const string BUTTON_TITLE_TEXT = "Title";
        public const string COLUMN_NAME_BUTTONS = "ButtonsList";
        public const string COLUMN_NAME_DESCRIPTIONS = "Description";

        public HomePage()
        {
            InitializeComponent();
            AppManager appManager = AppManager.getInstance();
            UserDetails userDetails = appManager.GetUserDetails();
            DataContext = userDetails;
            InitializeCustomComponents();
        }

        public void InitializeCustomComponents()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn(COLUMN_NAME_BUTTONS, Type.GetType("PhysioApplication.ButtonsList")));
            dataTable.Columns.Add(new DataColumn(COLUMN_NAME_DESCRIPTIONS, Type.GetType("System.String")));

            System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager("PhysioApplication.Properties.Resources", Assembly.GetExecutingAssembly());
            int noOfButtons = Convert.ToInt32(resourceManager.GetString(NO_OF_BUTTONS));
            for (int i = 1; i < noOfButtons + 1; i++)
            {
                string buttonDescription = resourceManager.GetString(BUTTON_TEXT + i + BUTTON_DESCRIPTION_TEXT);
                string buttonTitle = resourceManager.GetString(BUTTON_TEXT + i + BUTTON_TITLE_TEXT);
                dataTable.Rows.Add(new ButtonsList { Content = buttonTitle, ToolTip = buttonTitle }, buttonDescription);
            }
            dtGrid.ItemsSource = dataTable.DefaultView;
        }
    }

    public class ButtonsList
    {
        public String Content { get; set; }
        public string ToolTip { get; set; }
    }
}