using AccountsData;
using AccountsEntity;
using AccountsModel;
using System.Collections.Generic;
using System.Linq;

namespace AccountsFunction
{
    public class FRole : FAccountBase, IFRole
    {
        private IDRole _iDRole;

        public FRole(IDRole iDRoles)
        {
            _iDRole = iDRoles;
        }

        //Remove this when injector is implemented
        public FRole()
        {
            _iDRole = new DRole();

        }
        #region Create
        #endregion

        #region Read
        public List<Role> ReadRoles()
        {
            var eRoles = _iDRole.Read<ERole>(a => true, "RoleName");
            var roles = eRoles.Select(a => new Role
            {
                RoleID = a.RoleID,
                RoleName = a.RoleName
            });

            return roles.ToList();
        }

        public List<Role> ReadRoles(string username)
        {
            var eRoles = _iDRole.ReadRoles(username);
            var roles = eRoles.Select(a => new Role
            {
                RoleID = a.RoleID,
                RoleName = a.RoleName
            });

            return roles.ToList();
        }
        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion

        #region Other Function

        #endregion

    }
}
