using AccountsFunction;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountsWebAuthentication.Helper
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private IFUser _iFUser;

        public CustomAuthorizeAttribute()
        {
            _iFUser = new FUser();
        }

        public string[] AllowedRoles { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string currentUserlogged = WindowsUser.Username;
            try
            {
                return _iFUser.IsMethodAccessible(currentUserlogged, AllowedRoles.ToList());
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}