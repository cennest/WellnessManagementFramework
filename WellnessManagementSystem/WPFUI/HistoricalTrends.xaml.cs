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

namespace PhysioApplication
{
    /// <summary>
    /// Interaction logic for HistoricalTrends.xaml
    /// </summary>
    public partial class HistoricalTrends : Window
    {
        public HistoricalTrends()
        {
            InitializeComponent();
            LoadControls();
        }

        private void LoadControls()
        {
            BusinessLayerManager businessLayer = new BusinessLayerManager();
            lvCategory.ItemsSource = AppManager.getInstance().CurrentCategories;

        }
    }
}
