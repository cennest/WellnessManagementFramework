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
            this.listorders = new List<BOClient>();

            // Binding with the ChangedIndexCommand on GridPaging.........................................
            // Create de Command.
            this.changedIndex = new RoutedUICommand("ChangedIndex", "ChangedIndex", typeof(AllClientNotification));

            // Assing the command to GridPaging Command.
            gridPaging1.ChangedIndexCommand = this.changedIndex;

            // Binding Command
            CommandBinding abinding = new CommandBinding { Command = this.changedIndex };

            // Binding Handler to executed.
            abinding.Executed += this.OnChangeIndexCommandHandler;
            this.CommandBindings.Add(abinding);
            LoadData();
        }

        private readonly RoutedUICommand changedIndex;

        private IList<BOClient> listorders;

        private void LoadData()
        {
            gridPaging1.ResetPageIndex();
            var pageIndex = gridPaging1.PageIndex;
            var pageSize = gridPaging1.PageSize;
            gridPaging1.TotalCount = this.ExecuteQueryReturnTotalItem(pageIndex, pageSize);
        }

        private void OnChangeIndexCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            var pageIndex = gridPaging1.PageIndex;
            var pageSize = gridPaging1.PageSize;
            gridPaging1.TotalCount = this.ExecuteQueryReturnTotalItem(pageIndex, pageSize);
        }

        private int ExecuteQueryReturnTotalItem(int pageIndex, int pageSize)
        {
            int initialRow = ((pageIndex - 1) * pageSize);
            int finalRow = initialRow + pageSize;
            try
            {
                this.listorders = businessLayer.GetClientsforCategories(1, 1, initialRow, finalRow);
                this.dgOrdersGrid.ItemsSource = this.listorders;
                return businessLayer.GetCountOfClientsforCategories(1, 1, initialRow, finalRow);
            }
//            string connString = "Data Source=.;Initial Catalog=WellnessManagementFrameworkDB;Integrated Security=False;User ID=cennest; Password=cennest";
            //            var conn = new SqlConnection(connString);
            //            const string SqlQueryCount = "select count(ReportFieldId) from dbo.ReportFieldMaster";
            //            try
            //            {
            //                SqlCommand commcount = new SqlCommand(SqlQueryCount, conn);
            //                conn.Open();
            //                var rowCount = Convert.ToInt32(commcount.ExecuteScalar());
            //                const string SqlQuery =
            //                @"use WellnessManagementFrameworkDB;
            //                WITH Members AS
            //                (
            //                    select ROW_NUMBER() OVER (ORDER BY ReportFieldID ASC) as row, ReportFieldID, ReportFieldName
            //                    from  dbo.ReportFieldMaster
            //                )
            //                Select row, ReportFieldId, ReportFieldName
            //                from Members 
            //                where row BETWEEN  @InitialRow AND @EndRow order by row ASC;";

//                SqlCommand command = new SqlCommand(SqlQuery, conn);
            //                command.Parameters.AddWithValue("@InitialRow", initialRow);
            //                command.Parameters.AddWithValue("@EndRow", finalRow);

//                var reader = command.ExecuteReader();
            //                this.listorders = new List<BOClient>();
            //                while (reader.Read())
            //                {
            //                    var o = new BOClient
            //                    {
            //                        ClientID = Convert.ToInt32(reader["ReportFieldId"]),
            //                        ClientName = reader["ReportFieldName"].ToString(),
            //                        ClientNotes = "No Notes",
            //                        ClientNotification = "No Notification"
            //                    };
            //                    this.listorders.Add(o);
            //                }

//                this.dgOrdersGrid.ItemsSource = this.listorders;
            //                return rowCount;
            //            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            //finally
            //{
            //    if (conn.State != ConnectionState.Closed)
            //    {
            //        conn.Close();
            //    }
            //}
        }

    }
}
