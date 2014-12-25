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
using System.Dynamic;
using Editing;
using System.Collections.ObjectModel;

namespace PhysioApplication
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class LabReports : Window
    {

        public LabReports()
        {
            InitializeComponent();
            SetBreadCrumb();
            ucBreadCrumb.CrumbSelected += ucBreadCrumb_CrumbSelected;
        }

        void ucBreadCrumb_CrumbSelected(string selectedString)
        {
            AppManager.getInstance().BreadCrumbSelected(selectedString);
            this.Close();
        }

        private void SetBreadCrumb()
        {
            List<string>headers= new List<string>{"Home","All Athletes",AppManager.getInstance().CurrentClientName};
            ucBreadCrumb.ResetBreadCrumb(headers);
        }
    }


}
