using System.Web.Mvc;
using AccountsFunction;
using AndersonCRMFunction;
using AccountsWebAuthentication.Helper;

namespace AccountsWebAuthentication.Controllers
{
    public class BaseAccountsController : Controller
    {
        private IFUser _iFUser;
        private IFEmployee _iFEmployee;

        public BaseAccountsController()
        {
            _iFUser = new FUser();
            _iFEmployee = new FEmployee();
        }

        protected string Username
        {
            get
            {
                return WindowsUser.Username;
            }
        }

        protected int UserId
        {
            get
            {
                var user = _iFUser.Read(Username);
                int UserID = user?.UserId ?? 0;
                return UserID;
            }
        }

        protected int EmployeeId
        {
            get
            {
                var employee = _iFEmployee.Read(EmployeeId);
                int EmployeeID = employee?.EmployeeId ?? 0;
                return EmployeeID;
            }
        }

    }
}