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
using BusinessLayer.Entities;
using BusinessLayer;

namespace PhysioApplication{
    /// <summary>
    /// Interaction logic for AllClientNotification.xaml
    /// </summary>
    public partial class AllClientNotification : Window
    {
        BusinessLayerManager businessLayer = new BusinessLayerManager();

        public AllClientNotification()
        {
            InitializeComponent();
            BusinessLayerManager businessLayer = new BusinessLayerManager();
        }

        public List<BOClient> ClientSummary;
    }
}
