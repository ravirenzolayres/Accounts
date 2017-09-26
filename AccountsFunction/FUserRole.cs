using AccountsData;
using AccountsEntity;
using AccountsModel;
using System.Collections.Generic;
using System.Linq;

namespace AccountsFunction
{
    public class FUserRole : FAccountBase, IFUserRole
    {
        private IDUserRole _iDUserRole;

        public FUserRole(IDUserRole iDUserRoles)
        {
            _iDUserRole = iDUserRoles;
        }

        //Remove this when injector is implemented
        public FUserRole()
        {
            _iDUserRole = new DUserRole();

        }

        #region Create
        public void Create(List<Role> roles, int userId)
        {
            var userRoles = roles.Where(a => a.RoleStatus)
                .Select(a => new EUserRole
                {
                    RoleId = a.RoleId,
                    UserId = userId
                }).ToList();
            _iDUserRole.Create(userRoles);
        }
        #endregion

        #region Read

        #endregion

        #region Update
        public void Update(List<Role> roles, int userId)
        {
            var newUserRoles = roles.Where(a => a.RoleStatus && a.PreviousRoleStatus == false)
                .Select(a => new EUserRole
                {
                    RoleId = a.RoleId,
                    UserId = userId
                }).ToList();

            if (newUserRoles.Any())
                _iDUserRole.Create(newUserRoles);

            var oldUserRoles = roles.Where(a => a.RoleStatus == false && a.PreviousRoleStatus)
                .Select(a => new EUserRole
                {
                    RoleId = a.RoleId,
                    UserId = userId
                }).ToList();

            if (oldUserRoles.Any())
            {
                foreach (var userRoles in oldUserRoles)
                {
                    _iDUserRole.Delete<EUserRole>(a => a.UserId == userRoles.UserId && a.RoleId == userRoles.RoleId);
                }
            }
        }
        #endregion

        #region Delete

        #endregion

        #region Other Function

        #endregion
    }
}
