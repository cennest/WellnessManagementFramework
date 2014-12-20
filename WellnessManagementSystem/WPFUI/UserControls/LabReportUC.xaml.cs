using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
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
using BusinessLayer;
using BusinessLayer.Entities;
using Editing;

namespace PhysioApplication.UserControls
{
    /// <summary>
    /// Interaction logic for LabReportUC.xaml
    /// </summary>
    public partial class LabReportUC : UserControl
    {
        List<BOUserField> reportHeaders;
        ObservableCollection<ExpandoObject> currentLabReports;
        BusinessLayerManager businessLayer;
        public LabReportUC()
        {
            InitializeComponent();
            businessLayer = new BusinessLayerManager();
         
            AppManager appManager = AppManager.getInstance();
            List<BOLabReport> labReportsForUser = businessLayer.GetLabReportsForClient(1, appManager.GetUserDetails().UserID);
           reportHeaders=appManager.GetLabReportFieldsForUser();
            BindLabReportsOnListView(labReportsForUser, reportHeaders);
        }


        private DataTemplate GenerateTextBlockTemplate(string property)
        {
            FrameworkElementFactory factory = new FrameworkElementFactory(typeof(EditBox), "valueBox" + property);
            factory.SetBinding(EditBox.ValueProperty, new Binding { Path = new PropertyPath(property), Mode = BindingMode.TwoWay });

            DataTemplate t = new DataTemplate { VisualTree = factory };

            //uncomment this to enable 2-way explicit trigger
            // Application.Current.Resources.Add(property, t);
            return t;
        }



        private void BindLabReportsOnListView(List<BOLabReport> reports, List<BOUserField> reportHeaders)
        {
            try
            {
                GridView gridView = new GridView();
                GridViewColumn dateColumnHeader = new GridViewColumn();

                dateColumnHeader.CellTemplate = GenerateTextBlockTemplate("TestDate");// (DataTemplate)FindResource("textBoxDT");


                dateColumnHeader.Header = "Test Date";
                
                gridView.Columns.Add(dateColumnHeader);
                foreach (BOUserField reportHeader in reportHeaders)
                {
                    GridViewColumn columnHeader = new GridViewColumn();
                    columnHeader.CellTemplate = GenerateTextBlockTemplate(reportHeader.ReportFieldID.ToString());// (DataTemplate)FindResource("textBoxDT");

                    columnHeader.Header = reportHeader.ReportFieldName;
                    gridView.Columns.Add(columnHeader);
                }

                //Add a test date column seperately
                


                gridView.ColumnHeaderContainerStyle = this.FindResource("myHeaderStyle") as Style;
                

                lvReports.View = gridView;
                currentLabReports = generateLabReportsGroupedByDate(reports);
                lvReports.DataContext = currentLabReports;
                lvReports.ItemsSource = currentLabReports;
                lvReports.DataContextChanged += lvReports_DataContextChanged;
            }
            catch(Exception exception)
            {
                throw (exception);

            }
        }
        private ObservableCollection<ExpandoObject> generateLabReportsGroupedByDate(List<BOLabReport> reports)
        {
            try
            {
                List<DateTime> uniqueDates = (from report in reports
                                              select report.TestDate).Distinct().ToList();
                ObservableCollection<ExpandoObject> labReports = new ObservableCollection<ExpandoObject>();
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

                        //We want to add empty text fields for all other lab tests which were not conducted this day also
                        List<int> reportHeaderList = (from header in reportHeaders
                                                      select header.ReportFieldID).ToList();
                        List<int> dateReportIDs = (from dateReport in dateReports
                                                   select dateReport.ReportFieldID).ToList();
                        //find missing reports for this date
                        List<int> pendingReports = reportHeaderList.Except(dateReportIDs).ToList();
                        foreach (int pending in pendingReports)
                        {

                            report[pending.ToString()] = "N/A";
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            dynamic expando = new ExpandoObject();
            var report = expando as IDictionary<String, object>;
            report["TestDate"] = DateTime.Now.Date.ToShortDateString();
            foreach (BOUserField reportHeader in reportHeaders)
            {
                report[reportHeader.ReportFieldID.ToString()] = "N/A";
            }

            currentLabReports.Insert(0, expando);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            currentLabReports.RemoveAt(currentLabReports.Count - 1);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<ExpandoObject> editedReports = (ObservableCollection<ExpandoObject>)lvReports.DataContext;
            businessLayer.SaveEditedReportsForClient(1, editedReports);
        }
        
    }
}
