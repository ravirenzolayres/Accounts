using AccountsFunction;
using AccountsModel;
using AccountsWebAuthentication.Helper;
using AndersonCRMFunction;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Accounts.Controllers
{
    public class ViewPageController : BaseController
    {
        private IFEmployee _iFEmployee;
        private IFRole _iFRole;
        private IFUser _iFUser;
        private IFUserRole _iFUserRole;

        public ViewPageController()
        {
            _iFEmployee = new FEmployee();
            _iFRole = new FRole();
            _iFUser = new FUser();
            _iFUserRole = new FUserRole();

        }

        public string TestPage()
        {
            return WindowsUser.Username;
        }

        [CustomAuthorize(AllowedRoles = new string[] {"Account Manager"})]
        public ActionResult ManageAccount()
        {
            return View();
        }
        
        [CustomAuthorize(AllowedRoles = new string[] { "Supplier Provider" })]
        public ActionResult SupplierProvider()
        {
            return View();
        }
        
        [CustomAuthorize(AllowedRoles = new string[] { "Reviewer" })]
        public ActionResult Reviewer()
        {
            return View();
        }

        public ActionResult ForAll()
        {
            return View();
        }

        public JsonResult LoadRoles()
        {
            return Json(_iFRole.ReadRoles());
        }

        public JsonResult ReadEmployees()
        {
            return Json(_iFEmployee.List());
        }

        public JsonResult LoadPageData()
        {
            return Json(_iFUser.ReadUsers());
        }

        [HttpPost]
        public JsonResult AddUser(User user, List<Role> roles)
        {
            try
            {            
                user = _iFUser.Create(user);
                _iFUserRole.Create(roles, user.UserID);
            }
            catch (Exception ex)
            {
                return Json(ex.ToString());
            }
            return Json(string.Empty);
        }

        public JsonResult EditUser(User user)
        {
            try
            {
                _iFUser.Update(user);

                _iFUserRole.Update(user.Roles, user.UserID);
            }
            catch (Exception ex)
            {
                return Json(ex.ToString());
            }
            return Json(string.Empty);
        }

        public JsonResult ChangeStatus(int userid)
        {
            try
            {
                _iFUser.ChangeStatus(userid);
            }
            catch (Exception)
            {
                throw;
            }
            return Json(string.Empty);
        }

        public JsonResult DeleteUser(int userId)
        {
            try
            {
                User user = new User
                {
                    UserID = userId
                };
                _iFUser.Delete(user);
                return Json(LoadPageData());
            }
            catch (Exception ex)
            {
                return Json(ex.ToString());
            }
        }      
    }  
}