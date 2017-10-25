using AccountsData;
using AccountsEntity;
using AccountsModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountsFunction
{
    public class FUserRole : IFUserRole
    {
        private IDUserRole _iDUserRole;

        public FUserRole(IDUserRole iDUserRoles)
        {
            _iDUserRole = iDUserRoles;
        }

        public FUserRole()
        {
            _iDUserRole = new DUserRole();

        }

        #region Create
        public void Create(int createdBy, int userId, List<UserRole> userRoles)
        {
            Delete(userId);

            if (!userRoles?.Any() ?? true)
                return;

            var eUserRoles = EUserRole(createdBy, userId, userRoles);
            _iDUserRole.Create(eUserRoles);
        }
        #endregion

        #region Read

        #endregion

        #region Update
        #endregion

        #region Delete
        private void Delete(int userId)
        {
            _iDUserRole.Delete<EUserRole>(a => a.UserId == userId);
        }
        #endregion

        #region Other Function
        private List<EUserRole> EUserRole(int createdBy, int userId, List<UserRole> userRoles)
        {
            return userRoles.Select(a =>
            new EUserRole
            {
                CreatedDate = DateTime.Now,
                UpdatedDate = a.UpdatedDate,
                
                CreatedBy = createdBy,
                RoleId = a.RoleId,
                UpdatedBy = a.UpdatedBy,
                UserRoleId = a.UserRoleId,
                UserId = userId
            }).ToList();
        }
        #endregion
    }
}
