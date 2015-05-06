using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Entities;
using DataLayer;

namespace BusinessLayer
{
  public partial  class BusinessLayerManager
    {

      public List<KeyValuePair<string, List<KeyValuePair<DateTime, float>>>> GetDataForCategoryLevelReport(int userID, int testID, DateTime startDate, DateTime toDate, int categoryID)
      {
          //List<List<KeyValuePair<DateTime,float>>> playerLists = new List<List<KeyValuePair<DateTime,float>>>();
          List<KeyValuePair<string, List<KeyValuePair<DateTime, float>>>> playerLists2 = new List<KeyValuePair<string, List<KeyValuePair<DateTime, float>>>>();
               DataLayerManager dataLayer = new DataLayerManager();
              List<int> clientList = dataLayer.GetClientsForCategoryID(categoryID, userID);
              if (clientList.Count > 0)
              {
                  foreach (int clientID in clientList)
                  {
                      string clientName = dataLayer.GetClientNameClientID(clientID);
                      List<KeyValuePair<DateTime, float>> listOfTestValues = new List<KeyValuePair<DateTime, float>>();
                      List<BOLabReport> labReports = this.GetLabReportsForClientID(clientID, userID, testID);
                      foreach(BOLabReport report in labReports)
                      {
                          listOfTestValues.Add(new KeyValuePair<DateTime, float>(report.TestDate, float.Parse(report.ReportFieldValue)));
                      }
                      playerLists2.Add(new KeyValuePair<string, List<KeyValuePair<DateTime, float>>>(clientName, listOfTestValues));
                      //playerLists.Add(listOfTestValues);
                  }
              }
          return playerLists2;
       
      }

      public Hashtable GetLabReportsForCategory(int categoryID, int reportID, int userID)
      {
          try
          {
              DataLayerManager dataLayer = new DataLayerManager();
              List<int> clientList = dataLayer.GetClientsForCategoryID(categoryID, userID);
              Hashtable listOfClientsReportHasTable = new Hashtable();
              if (clientList.Count > 0)
              {
                  foreach (int clientID in clientList)
                  {
                      List<BOLabReport> labReports = this.GetLabReportsForClientID(clientID, userID, reportID);
                      listOfClientsReportHasTable.Remove(clientID);
                      listOfClientsReportHasTable.Add(clientID, labReports);
                  }
              }
              return listOfClientsReportHasTable;
          }
          catch (Exception exception)
          {
              throw (exception);
          }
      }
    }
}
