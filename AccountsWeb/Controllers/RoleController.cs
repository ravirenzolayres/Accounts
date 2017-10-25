using AccountsFunction;
using AccountsWebAuthentication.Helper;
using System.Web.Mvc;

namespace AccountsWeb.Controllers
{
    [CustomAuthorize(AllowedRoles = new string[] { "AccountAdministrator" })]
    public class RoleController : BaseController
    {
        private IFRole _iFRole;
        public RoleController(IFRole iFRole)
        {
            _iFRole = iFRole;
        }

        #region Create
        #endregion

        #region Read
        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFRole.Read("Name"));
        }

        [HttpPost]
        public JsonResult ReadAssignedRole(int id)
        {
            return Json(_iFRole.Read(id, "Name"));
        }
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion
    }
}