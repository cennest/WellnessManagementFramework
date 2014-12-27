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
using System.Windows.Navigation;

namespace PhysioApplication
{
    /// <summary>
    /// Interaction logic for AllClientNotification.xaml
    /// </summary>
    public partial class AllClientNotification : Window
    {
        BusinessLayerManager businessLayer = new BusinessLayerManager();
        private readonly RoutedUICommand changedIndex;
        private List<BOClient> clientList;
        private List<BOClient> clientListByCategory;
        private List<BOCategory> categoryList;
        private List<ComboBoxItem> comboBoxItemList;
        private int userID;
        public AllClientNotification()
        {
            InitializeComponent();
            this.clientList = new List<BOClient>();
            this.clientListByCategory = new List<BOClient>();
            BOUser userDetail = new BOUser();
            userDetail = AppManager.getInstance().GetUserDetails();
            this.userID = userDetail.UserID;

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
            this.categoryList = businessLayer.GetAllCategories();
            this.comboBoxItemList = new List<ComboBoxItem>();
            foreach (BOCategory category in categoryList)
            {
                comboBoxItemList.Add(new ComboBoxItem { Content = category.CategoryName, Tag = category.CategoryID.ToString() });
            }
            this.cbPageFilter.ItemsSource = this.comboBoxItemList;
            this.cbPageFilter.SelectedIndex = 0;
            LoadData();
            SetBreadCrumb();
        }

        private void SetBreadCrumb()
        {
        List<string>headers= new List<string>{"Home","All Athletes"};
        ucBreadCrumb.ResetBreadCrumb(headers);
        ucBreadCrumb.CrumbSelected += ucBreadCrumb_CrumbSelected;
        
        }

        void ucBreadCrumb_CrumbSelected(string selectedString)
        {
            AppManager.getInstance().BreadCrumbSelected(selectedString);
            this.Close();
        }

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
            int CategoryID = Convert.ToInt32(((ComboBoxItem)this.cbPageFilter.SelectedItem).Tag);
            int initialRow = ((pageIndex - 1) * pageSize);
            int finalRow = initialRow + pageSize;
            try
            {
                int cachedDataCount = this.clientListByCategory.Count;
                if (cachedDataCount < finalRow)
                {
                    FetchDataFromDatabase(cachedDataCount, initialRow, finalRow, CategoryID);
                }
                else
                {
                    FetchDataFromCache(initialRow, finalRow);
                }
                this.ClientDataGrid.ItemsSource = this.clientList;
                int totalRow = businessLayer.GetCountOfClientsforCategories(CategoryID, this.userID, initialRow, finalRow);
                return totalRow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        private void FetchDataFromDatabase(int cachedDataCount, int initialRow, int finalRow,  int CategoryID)
        {
            this.clientList = businessLayer.GetClientsforCategories(CategoryID, this.userID, initialRow, finalRow);
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

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (textBlock != null)
            {
                AppManager.getInstance().currentClientID = Convert.ToInt32(textBlock.Tag);
                AppManager.getInstance().CurrentClientName = textBlock.Text;
                UserReports labReports = new UserReports();
                labReports.ShowDialog();
                
                this.Close();
            }
        }

        private void FilterComboBoxSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this.clientListByCategory = new List<BOClient>();
            LoadData();
        }
    }
}
