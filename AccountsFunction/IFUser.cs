using AccountsModel;
using System.Collections.Generic;

namespace AccountsFunction
{
    public interface IFUser
    {
        #region Create
        User Create(User user);
        #endregion

        #region Read
        bool IsMethodAccessible(string Username, List<string> AllowedRoles);
        User ReadUser(string Username);
        List<User> ReadUsers();
        #endregion

        #region Update
        User Update(User user);
        void ChangeStatus(int userId);
        #endregion

        #region Delete
        void Delete(User user);
        #endregion

        #region Other Function

        #endregion
    }
}
