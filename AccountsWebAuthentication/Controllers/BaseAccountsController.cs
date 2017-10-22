    using System.Web.Mvc;
using AccountsFunction;
using AccountsWebAuthentication.Helper;

namespace AccountsWebAuthentication.Controllers
{
    public class BaseAccountsController : Controller
    {
        private IFUser _iFUser;

        public BaseAccountsController()
        {
            _iFUser = new FUser();
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

    }
}