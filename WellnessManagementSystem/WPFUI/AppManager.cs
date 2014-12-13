using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Entities;

namespace PhysioApplication
{
    public class AppManager
    {
        private static AppManager instance = null;
        private BOUser userDetails;
        private List<BOUserField> labReportFieldsForUser;

        private AppManager()
        {

        }

        public static AppManager getInstance()
        {
            if (instance == null)
            {
                instance = new AppManager();
            }
            return instance;
        }

        public void SetUserDetails(BOUser userDetails)
        {
            this.userDetails = userDetails;
        }

        public BOUser GetUserDetails()
        {
            return this.userDetails;
        }

        public void SetLabReportFieldsForUser(List<BOUserField> labReportFields)
        {
            this.labReportFieldsForUser = labReportFields;
        }

        public List<BOUserField> GetLabReportFieldsForUser()
        {
            return this.labReportFieldsForUser;
        }
    }
}
