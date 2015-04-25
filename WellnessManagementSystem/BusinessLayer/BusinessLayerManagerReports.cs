using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BusinessLayer.Entities;
using DatabaseEntities;
using System.Collections;
using System.Collections.ObjectModel;
using System.Dynamic;

namespace BusinessLayer
{
  public partial  class BusinessLayerManager
    {

      public  List<List<KeyValuePair<DateTime,float>>> GetDataForCategoryLevelReport(int userID, int testID, DateTime startDate, DateTime toDate,int categoryID )
      {
          List<List<KeyValuePair<DateTime,float>>> playerLists = new List<List<KeyValuePair<DateTime,float>>>();

              DataLayerManager dataLayer = new DataLayerManager();
              List<int> clientList = dataLayer.GetClientsForCategoryID(categoryID, userID);
              if (clientList.Count > 0)
              {
                  foreach (int clientID in clientList)
                  {
                      List<KeyValuePair<DateTime, float>> listOfTestValues = new List<KeyValuePair<DateTime, float>>();

                      List<BOLabReport> labReports = this.GetLabReportsForClientID(clientID, userID, testID);
                      foreach(BOLabReport report in labReports)
                      {
                          listOfTestValues.Add(new KeyValuePair<DateTime, float>(report.TestDate, float.Parse(report.ReportFieldValue)));
                      }
                      playerLists.Add(listOfTestValues);
                  }
              }
          return playerLists;
       
      }

      public List<BOClient> GetClientWithReportData(int userID, int testID, int categoryID)
      {
          try
          {
              DataLayerManager dataLayer = new DataLayerManager();
              List<Client> clientList = dataLayer.GetClientsForCategory(categoryID, userID);
              List<BOClient> clients = GetClientBOForClientDBObjects(clientList);
              List<BOClient> listOfClients = null;
              if (clientList.Count > 0)
              {
                  listOfClients = new List<BOClient>();
                  foreach (BOClient client in clients)
                  {
                      List<KeyValuePair<DateTime, float>> listOfTestValues = new List<KeyValuePair<DateTime, float>>();
                      List<BOLabReport> labReports = this.GetLabReportsForClientID(client.ClientID, userID, testID);
                      if (labReports.Count > 0)
                      {
                          listOfClients.Add(client);
                      }
                  }
              }
              return listOfClients;
          }
          catch (Exception ex)
          {
              throw;
          }
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
