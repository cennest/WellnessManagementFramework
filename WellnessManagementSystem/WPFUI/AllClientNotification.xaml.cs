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
using System.Data;
using System.Data.SqlClient;

namespace PhysioApplication
{
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
            this.clientList = new List<BOClient>();
            this.clientListByCategory = new List<BOClient>();

            // Binding with the ChangedIndexCommand on GridPaging.........................................
            // Create de Command.
            this.changedIndex = new RoutedUICommand("ChangedIndex", "ChangedIndex", typeof(AllClientNotification));

            // Assing the command to GridPaging Command.
            gridPaging.ChangedIndexCommand = this.changedIndex;

            // Binding Command
            CommandBinding abinding = new CommandBinding { Command = this.changedIndex };

            // Binding Handler to executed.
            abinding.Executed += this.OnChangeIndexCommandHandler;
            this.CommandBindings.Add(abinding);
            LoadData();
        }

        private readonly RoutedUICommand changedIndex;

        private IList<BOClient> clientList;
        private IList<BOClient> clientListByCategory;

        private void LoadData()
        {
            gridPaging.ResetPageIndex();
            var pageIndex = gridPaging.PageIndex;
            var pageSize = gridPaging.PageSize;
            gridPaging.TotalCount = this.ExecuteQueryReturnTotalItem(pageIndex, pageSize);
        }

        private void OnChangeIndexCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            var pageIndex = gridPaging.PageIndex;
            var pageSize = gridPaging.PageSize;
            gridPaging.TotalCount = this.ExecuteQueryReturnTotalItem(pageIndex, pageSize);
        }

        private int ExecuteQueryReturnTotalItem(int pageIndex, int pageSize)
        {
            int initialRow = ((pageIndex - 1) * pageSize);
            int finalRow = initialRow + pageSize;
            try
            {
                int cachedDataCount = this.clientListByCategory.Count;
                if (cachedDataCount < finalRow)
                {
                    FetchDataFromDatabase(cachedDataCount, initialRow, finalRow);
                }
                else
                {
                    FetchDataFromCache(initialRow, finalRow);
                }
                this.ClientDataGrid.ItemsSource = this.clientList;
                return businessLayer.GetCountOfClientsforCategories(1, 1, initialRow, finalRow);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        private void FetchDataFromDatabase(int cachedDataCount, int initialRow, int finalRow)
        {
            this.clientList = businessLayer.GetClientsforCategories(1, 1, initialRow, finalRow);
            int skip = cachedDataCount - initialRow;
            int rowCounter = 0;
            if (this.clientList.Count > 0)
            {
                foreach (BOClient client in this.clientList)
                {
                    rowCounter++;
                    if (rowCounter > skip)
                    {
                        this.clientListByCategory.Add(client);
                    }
                }
            }
        }

        private void FetchDataFromCache(int initialRow, int finalRow)
        {
            this.clientList = new List<BOClient>();
            if (this.clientListByCategory.Count > 0)
            {
                int rowCounter = 0;
                foreach (BOClient client in this.clientListByCategory)
                {
                    rowCounter++;
                    if (rowCounter > finalRow)
                    {
                        break;
                    }
                    if (rowCounter <= initialRow)
                    {
                        continue;
                    }
                    this.clientList.Add(client);
                }
            }
        }
    }
}
