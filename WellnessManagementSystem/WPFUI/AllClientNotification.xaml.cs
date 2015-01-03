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
using System.Collections;

namespace PhysioApplication
{
    /// <summary>
    /// Interaction logic for AllClientNotification.xaml
    /// </summary>
    public partial class AllClientNotification : Window
    {
        BusinessLayerManager businessLayer = new BusinessLayerManager();
        private readonly RoutedUICommand changedIndex;
        private Hashtable listOfAllClientsByCategoryHasTable;
        private int userID;
        private bool isSearchByName;
        private string nameToSearch;
        public AllClientNotification()
        {
            InitializeComponent();
            this.listOfAllClientsByCategoryHasTable = new Hashtable();
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
                List<BOClient> clientList = this.GetClientList(CategoryID, skip, take, finalRow);
                this.ClientDataGrid.ItemsSource = clientList;
                int totalRow = this.GetTotalNumberOfRows(CategoryID);
                return totalRow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        private List<BOClient> GetClientList(int CategoryID, int skip, int take, int finalRow)
        {
            List<BOClient> clientList = new List<BOClient>();
            if (this.isSearchByName == true)
            {
                clientList = businessLayer.GetClientsForCategoryByName(CategoryID, this.nameToSearch, this.userID, skip, take);
            }
            else
            {
                List<BOClient> clientListByCategory = (List<BOClient>)this.listOfAllClientsByCategoryHasTable[CategoryID];
                if (clientListByCategory == null)
                {
                    clientListByCategory = new List<BOClient>();
                }
                int cachedDataCount = clientListByCategory.Count;
                if (cachedDataCount < finalRow)
                {
                    FetchDataFromDatabaseToTemporaryStorage(cachedDataCount, skip, take, CategoryID);
                }
                clientList = FetchDataFromTemporaryStorage(skip, take, CategoryID);
            }
            return clientList;
        }

        private int GetTotalNumberOfRows(int CategoryID)
        {
            try
            {
                int totalRow = 0;
                if (this.isSearchByName == true)
                {
                    totalRow = businessLayer.GetCountOfClientsForCategoryByName(CategoryID, this.nameToSearch, this.userID);
                }
                else
                {
                    totalRow = businessLayer.GetCountOfClientsforCategories(CategoryID, this.userID);
                }
                return totalRow;
            }
            catch (Exception ex)
            {
                return 0;
            }
        } 

        private void FetchDataFromDatabaseToTemporaryStorage(int cachedDataCount, int skip, int take, int CategoryID)
        {
            try
            {
                List<BOClient> clientListByCategory = (List<BOClient>)this.listOfAllClientsByCategoryHasTable[CategoryID];
                if (clientListByCategory == null)
                {
                    clientListByCategory = new List<BOClient>();
                }
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
                            clientListByCategory.Add(client);
                        }
                    }
                    this.listOfAllClientsByCategoryHasTable.Remove(CategoryID);
                    this.listOfAllClientsByCategoryHasTable.Add(CategoryID, clientListByCategory);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<BOClient> FetchDataFromTemporaryStorage(int skip, int take, int CategoryID)
        {
            try
            {
                List<BOClient> listOfClients = new List<BOClient>();
                List<BOClient>  clientListByCategory = (List<BOClient>)this.listOfAllClientsByCategoryHasTable[CategoryID];
                if (clientListByCategory == null)
                {
                    clientListByCategory = new List<BOClient>();
                }
                if (clientListByCategory.Count > 0)
                {
                    listOfClients = clientListByCategory.Skip(skip).Take(take).ToList();
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
        void uc_OptionChanged(bool isSearchByName, string name)
        {
            this.isSearchByName = isSearchByName;
            if (this.isSearchByName == true)
            {
                this.nameToSearch = name;
            }
            LoadData();
        }
    }
}
