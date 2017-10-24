using AccountsModel;
using System.Collections.Generic;

namespace AccountsFunction
{
    public interface IFUser
    {
        #region Create
        User Create(int createdBy, User user);
        #endregion

        #region Read
        bool IsMethodAccessible(string username, List<string> allowedRoles);
        User Read(int userId);
        User Read(string username);
        List<User> Read();
        #endregion

        #region Update
        User Update(int updatedBy, User user);
        #endregion

        #region Delete
        void Delete(int userId);
        #endregion

        #region Other Function

        #endregion
    }
}
