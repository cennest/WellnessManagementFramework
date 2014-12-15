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
            BusinessLayerManager businessLayer = new BusinessLayerManager();
         
            AppManager appManager = AppManager.getInstance();
            List<BOLabReport> labReportsForUser = businessLayer.GetLabReportsForClient(1, appManager.GetUserDetails().UserID);
            List<BOUserField> labReportFieldsForUser=appManager.GetLabReportFieldsForUser();
            BindLabReportsOnListView(labReportsForUser, labReportFieldsForUser);
        }

        private void BindLabReportsOnListView(List<BOLabReport> reports, List<BOUserField> reportHeaders)
        {
            try
            {
                GridView gridView = new GridView();
                GridViewColumn dateColumnHeader = new GridViewColumn();

                dateColumnHeader.DisplayMemberBinding = new Binding("TestDate");

                dateColumnHeader.Header = "Test Date";
                
                gridView.Columns.Add(dateColumnHeader);
                foreach (BOUserField reportHeader in reportHeaders)
                {
                    GridViewColumn columnHeader = new GridViewColumn();
                    //we want to bind based on the ReportFieldID
                    columnHeader.DisplayMemberBinding = new Binding(reportHeader.ReportFieldID.ToString());
                    columnHeader.Header = reportHeader.ReportFieldName;
                    gridView.Columns.Add(columnHeader);
                }

                //Add a test date column seperately
                


                gridView.ColumnHeaderContainerStyle = this.FindResource("myHeaderStyle") as Style;
                

                lvReports.View = gridView;
                var expandoReports = generateLabReportsGroupedByDate(reports);
                lvReports.DataContext = expandoReports;
                lvReports.ItemsSource = expandoReports;
                lvReports.DataContextChanged += lvReports_DataContextChanged;
            }
            catch(Exception exception)
            {
                throw (exception);

            }
        }
        private List<ExpandoObject> generateLabReportsGroupedByDate(List<BOLabReport> reports)
        {
            try
            {
                List<DateTime> uniqueDates = (from report in reports
                                              select report.TestDate).Distinct().ToList();
                List<ExpandoObject> labReports = new List<ExpandoObject>();
                foreach (DateTime date in uniqueDates)
                {
                    dynamic expando = new ExpandoObject();
                    var report = expando as IDictionary<String, object>;
                    report["TestDate"] = date.Date.ToShortDateString();
                    List<BOLabReport> dateReports = reports.Where(r => r.TestDate == date).ToList();
                    if (dateReports.Count > 0)
                    {
                        foreach (BOLabReport dateR in dateReports)
                        {
                            //this will help us identify the record in the LabReport table when we want to edit the value
                            report["ReportID"] = dateR.LabReportID;
                            //create a property with property name=the ReportFieldID so that it gets bound to the correct column
                            report[dateR.ReportFieldID.ToString()] = dateR.ReportFieldValue;

                        }
                        labReports.Add(expando);
                    }
                }
                return labReports;
            }
            catch (Exception exception)
            {
                throw (exception);
            }
        }
        void lvReports_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void AddLabReport_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
