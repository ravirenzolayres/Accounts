using AccountsData;
using AccountsEntity;
using AccountsModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountsFunction
{
    public class FUser : IFUser
    {
        private IDUser _iDUser;

        public FUser(IDUser iDUser)
        {
            _iDUser = iDUser;
        }

        public FUser()
        {
            _iDUser = new DUser();
        }

        #region Create
        public User Create(int createdBy, User user)
        {

            var eUser = EUser(user);
            eUser.CreatedDate = DateTime.Now;
            eUser.CreatedBy = createdBy;
            eUser = _iDUser.Insert(eUser);
            return User(eUser);
        }
        #endregion

        #region Read
        public bool IsMethodAccessible(string username, List<string> allowedRoles)
        {
            if (allowedRoles.Count == 0)
            {
                return _iDUser.Exists<EUser>(a => a.Username == username && a.IsActive);
            }
            else
            {
                return _iDUser.Exists<EUser>(a => a.Username == username && a.IsActive && a.UserRoles.Any(b => allowedRoles.Contains(b.Role.Name)));
            }
        }

        public User Read(string username)
        {
            var eUser = _iDUser.Read<EUser>(a => a.Username == username);
            return User(eUser);
        }
        public List<User> Read()
        {
            var eUsers = _iDUser.Read<EUser>(a => true, "Username");
            return Users(eUsers);
        }
        #endregion

        #region Update
        public User Update(int updatedBy, User user)
        {
            var eUser = EUser(user);
            eUser.UpdatedDate = DateTime.Now;
            eUser.UpdatedBy = updatedBy;
            eUser = _iDUser.Update(eUser);
            return User(eUser);
        }
        #endregion

        #region Delete
        public void Delete(int userId)
        {
            _iDUser.Delete<EUser>(a => a.UserId == userId);
        }
        #endregion

        #region Other Function
        private EUser EUser(User user)
        {
            return new EUser
            {
                IsActive = user.IsActive,
                
                CreatedDate = user.CreatedDate,
                UpdatedDate = user.UpdatedDate,

                CreatedBy = user.CreatedBy,
                EmployeeId = user.EmployeeId,
                UpdatedBy = user.UpdatedBy,
                UserId = user.UserId,

                Username = user.Username
            };
        }

        private User User(EUser eUser)
        {
            return new User
            {
                IsActive = eUser.IsActive,

                CreatedDate = eUser.CreatedDate,
                UpdatedDate = eUser.UpdatedDate,

                CreatedBy = eUser.CreatedBy,
                EmployeeId = eUser.EmployeeId,
                UpdatedBy = eUser.UpdatedBy,
                UserId = eUser.UserId,

                Username = eUser.Username
            };
        }

        private List<User> Users(List<EUser> eUsers)
        {
            return eUsers.Select(a => new User
            {
                IsActive = a.IsActive,

                CreatedDate = a.CreatedDate,
                UpdatedDate = a.UpdatedDate,

                CreatedBy = a.CreatedBy,
                EmployeeId = a.EmployeeId,
                UpdatedBy = a.UpdatedBy,
                UserId = a.UserId,

                Username = a.Username
            }).ToList();
        }
        #endregion
    }
}
