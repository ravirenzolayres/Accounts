using AccountsData;
using AccountsEntity;
using AccountsModel;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace AccountsFunction
{
    public class FUser : FAccountBase, IFUser
    {
        private IDRole _iDRoles;
        private IDUser _iDUser;

        public FUser(IDRole iDRole, IDUser iDUser)
        {
            _iDRoles = iDRole;
            _iDUser = iDUser;
        }

        public FUser()
        {
            _iDRoles = new DRole();
            _iDUser = new DUser();
        }

        #region Create
        public User Create(User user)
        {

            var eUser = Mapper.Map<EUser>(user);
            eUser = _iDUser.Insert(eUser);
            user = Mapper.Map<User>(eUser);
            return (user);
        }
        #endregion

        #region Read
        public bool IsMethodAccessible(string Username, List<string> AllowedRoles)
        {
            if (AllowedRoles.Count == 0)
            {
                return _iDUser.IsUserExist(Username);
            }
            else
            {
                return _iDUser.IsMethodAccessible(Username, AllowedRoles);
            }
        }
        public User ReadUser(string Username)
        {
            var eUser = _iDUser.Read<EUser>(a => a.Username == Username);
            return Mapper.Map<User>(eUser);
        }
        public List<User> ReadUsers()
        {
            var eUsers = _iDUser.ReadUsers();
            var eRoles = _iDRoles.List<ERole>(a => true);
            return eUsers.Select(a => new User
            {
                UserID = a.UserID,
                Username = a.Username,
                Firstname = a.Firstname,
                EmployeeId = a.EmployeeId,
                Status = a.Status,
                Roles = eRoles.Select(b =>
                    new Role
                    {
                        RoleID = b.RoleID,
                        RoleName = b.RoleName,
                        RoleStatus = a.UserRole.Any(c => c.RoleId == b.RoleID)
                    }).ToList()
            }).ToList();
        }
        #endregion

        #region Update
        public User Update(User user)
        {
            var eUser = Mapper.Map<EUser>(user);
            eUser = _iDUser.Update(eUser);
            return Mapper.Map<User>(eUser);
        }

        public void ChangeStatus(int userId)
        {
            var eUser = _iDUser.Read<EUser>(a => a.UserID == userId);
            eUser.Status = !eUser.Status;
            _iDUser.Update(eUser);
        }
        #endregion

        #region Delete
        public void Delete(User user)
        {
            var eUser = Mapper.Map<EUser>(user);
            _iDUser.Delete(eUser);
        }
        #endregion

        #region Other Function

        #endregion
    }
}
