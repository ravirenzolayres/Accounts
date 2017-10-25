using AccountsModel;
using System.Collections.Generic;


namespace AccountsFunction
{
    public interface IFRole
    {
        #region Create

        #endregion

        #region Read
        List<Role> Read(string sortBy);
        List<Role> Read(int userId, string sortBy);
        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion

        #region Other Function

        #endregion
    }
}
