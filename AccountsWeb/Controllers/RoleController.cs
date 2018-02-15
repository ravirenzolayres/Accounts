using AccountsFunction;
using AccountsModel;
using AccountsWebAuthentication.Helper;
using System;
using System.Web.Mvc;
using System.Web.UI;

namespace AccountsWeb.Controllers
{
    [CustomAuthorize(AllowedRoles = new string[] { "AccountAdministrator"})]
    public class RoleController : BaseController
    {
        private IFRole _iFRole;
        public RoleController(IFRole iFRole)
        {
            _iFRole = iFRole;
        }

        #region Create
        [HttpGet]
        public ActionResult Create()    
        {
            return View(new Role());
        }
        [HttpPost]
        public ActionResult Create(Role role)
        {
            try {
                var createdRole = _iFRole.Create(UserId, role);
                if (ModelState.IsValid)
                {
                    TempData["message"] = "Role has been created, successfully!";
                }
                return RedirectToAction("Create");
            }
            catch (Exception)
            {
                if (ModelState.IsValid)
                {
                    // Do your stuff
                    TempData["message"] = "Opps! Something went wrong. Please, try again.";
                }
                return RedirectToAction("Create");

            }
           
        }
        #endregion

        #region Read
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

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
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_iFRole.Read(id));
        }
        [HttpPost]
        public ActionResult Update(Role role)
        {
            try
            {
                var createdRole = _iFRole.Update(UserId, role);
                if (ModelState.IsValid)
                {
                    TempData["message"] = "Role has been updated, successfully!";
                }
                return RedirectToAction("Create");
            }
            catch (Exception)
            {
                if (ModelState.IsValid)
                {
                    // Do your stuff
                    TempData["message"] = "Opps! Something went wrong. Please, try again.";
                }
                return RedirectToAction("Create");

            }

        }

        #endregion

        #region Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            _iFRole.Delete(id);
            return Json(string.Empty);
        }
        #endregion
    }
}