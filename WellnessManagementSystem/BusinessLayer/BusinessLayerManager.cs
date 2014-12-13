using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DatabaseEntities;
using BusinessLayer.Entities;


namespace BusinessLayer
{
    public class BusinessLayerManager
    {
        public BOUserDetails GetUser(string userName, string password)
        {
            try
            {
                DataLayerManager datalayer = new DataLayerManager();
                User user = datalayer.GetUser(userName, password);

                if (user != null)
                {
                    BOUserDetails appUser = new BOUserDetails();
                    appUser.UserID = user.UserId;
                    appUser.UserName = user.UserName;
                    appUser.OccupationID = user.OccupationID;
                    return appUser;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<BOCategory> GetAllCategories()
        {
            try
            {
                DataLayerManager datalayer = new DataLayerManager();
                List<CategoryMaster> listOfCategories = datalayer.GetAllCategories();
                List<BOCategory> Categories = new List<BOCategory>();
                if (listOfCategories.Count > 0)
                {
                    foreach (CategoryMaster category in listOfCategories)
                    {
                        BOCategory categoryObject = new BOCategory();
                        categoryObject.CategoryID = category.CategoryID;
                        categoryObject.CategoryName = category.CategoryName;
                        Categories.Add(categoryObject);
                    }
                }
                return Categories;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<BOClient> GetClientsforCategories(int categoryID, int userID, int skip, int take)
        {
            try
            {
                DataLayerManager datalayer = new DataLayerManager();
                List<Client> listOfClients = datalayer.GetClientsforCategories(categoryID, userID, skip, take);
                List<BOClient> clients = GetClientBOForClientDBObjects(listOfClients);
                return clients;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<BOClient> GetClientsForCategoryByName(int categoryID, string searchString, int userID, int skip, int take)
        {
            try
            {
                DataLayerManager datalayer = new DataLayerManager();
                List<Client> listOfClients = datalayer.GetClientsforCategories(categoryID, userID, skip, take);
                List<BOClient> clients = GetClientBOForClientDBObjects(listOfClients);
                return clients;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        private List<BOClient> GetClientBOForClientDBObjects(List<Client> clients)
        {
            List<BOClient> listOfClients = new List<BOClient>();
            if (clients.Count > 0)
            {
                foreach (Client client in clients)
                {
                    BOClient clientObject = new BOClient();
                    clientObject.ClientID = client.ClientID;
                    clientObject.ClientName = client.ClientName;
                    listOfClients.Add(clientObject);
                }
            }
            return listOfClients;
        }
    }
}
