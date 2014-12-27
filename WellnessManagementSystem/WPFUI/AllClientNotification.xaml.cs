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
        private List<BOClient> clientListByCategory;
        private int userID;
        public AllClientNotification()
        {
            InitializeComponent();
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
            //ucFilterUC.OptionChanged += new UserControls.FilterUC.OptionChangedEventHandler(uc_OptionChanged);
            LoadData();
            SetBreadCrumb();
        }

        private void SetBreadCrumb()
        {
            List<string> headers = new List<string> { "Home", "All Athletes" };
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

        private int ExecuteQueryReturnTotalItem(int pageIndex, int take)
        {
            int CategoryID = Convert.ToInt32(((ComboBoxItem)ucFilterUC.cbPageFilter.SelectedItem).Tag);
            int skip = ((pageIndex - 1) * take);
            int finalRow = skip + take;
            try
            {
                int cachedDataCount = this.clientListByCategory.Count;
                if (cachedDataCount < finalRow)
                {
                    FetchDataFromDatabaseToTemporaryStorage(cachedDataCount, skip, take, CategoryID);
                }
                List<BOClient> clientList = FetchDataFromTemporaryStorage(skip, take);
                this.ClientDataGrid.ItemsSource = clientList;
                int totalRow = businessLayer.GetCountOfClientsforCategories(CategoryID, this.userID);
                return totalRow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        private void FetchDataFromDatabaseToTemporaryStorage(int cachedDataCount, int skip, int take, int CategoryID)
        {
            try
            {
                List<BOClient> clientListForCategory = businessLayer.GetClientsforCategories(CategoryID, this.userID, skip, take);
                int skipDataFromAddingToCategoryList = cachedDataCount - skip;
                int rowCounter = 0;
                if (clientListForCategory.Count > 0)
                {
                    foreach (BOClient client in clientListForCategory)
                    {
                        rowCounter++;
                        if (rowCounter > skipDataFromAddingToCategoryList)
                        {
                            this.clientListByCategory.Add(client);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<BOClient> FetchDataFromTemporaryStorage(int skip, int take)
        {
            try
            {
                List<BOClient> listOfClients = new List<BOClient>();
                if (this.clientListByCategory.Count > 0)
                {
                    listOfClients = this.clientListByCategory.Skip(skip).Take(take).ToList();
                }
                return listOfClients;
            }
            catch (Exception ex)
            {
                return new List<BOClient>();
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
        void uc_OptionChanged()
        {
            this.clientListByCategory = new List<BOClient>();
            LoadData();
        }
    }
}
