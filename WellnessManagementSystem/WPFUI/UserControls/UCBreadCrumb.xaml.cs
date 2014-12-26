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
    /// Interaction logic for UCBreadCrumb.xaml
    /// </summary>
    public partial class UCBreadCrumb : UserControl
    {
        public event crumbSelected CrumbSelected;
        public delegate void crumbSelected(string selectedString);

        public UCBreadCrumb()
        {
            InitializeComponent();
        }

        public bool AddBreadCrumb(string text, bool isLast)
        {
            if(lvBreadCrumb.Items.Count>0)
            {
                lvBreadCrumb.Items.Add(new ListViewItem { Content = ">" , IsHitTestVisible=false});
            }
            lvBreadCrumb.Items.Add(new ListViewItem{Content=text, IsEnabled= !isLast, FontWeight= isLast?FontWeights.Bold:FontWeights.Medium, Foreground=isLast?Brushes.Black:Brushes.Blue});
            return true;
        }
        public bool ResetBreadCrumb(List<string> crumbs)
        {
            lvBreadCrumb.Items.Clear();
            foreach (string crumb in crumbs)
            {
                if (crumbs.IndexOf(crumb) == crumbs.Count - 1)
                {
                    AddBreadCrumb(crumb, true);
                }
                else
                {
                    AddBreadCrumb(crumb, false);
                }
            }
            return true;
        }

        private void lvBreadCrumb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedString =(string)( (ListViewItem)lvBreadCrumb.SelectedItem).Content;
            if(CrumbSelected!=null)
            {
                CrumbSelected(selectedString);
            }
        }
    }
}
