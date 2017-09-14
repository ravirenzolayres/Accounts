using AndersonCRMModel;
using System.Collections.Generic;

namespace AccountsModel
{
    public class User
    {

        private int mEmployeeId { get; set; }

        public int UserID { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public int EmployeeId {
            get
            {
                if (Employee != null)
                {
                    return Employee.EmployeeId;
                }
                else if (mEmployeeId != 0)
                {
                    return mEmployeeId;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                mEmployeeId = value;
            }
        }
 
        public bool Status { get; set; }

        public Employee Employee { get; set; }

        public List<Role> Roles { get; set; }
    }
}
