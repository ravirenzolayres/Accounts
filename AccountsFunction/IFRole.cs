using AccountsModel;
using System.Collections.Generic;


namespace AccountsFunction
{
    public interface IFRole
    {
        #region Create

        #endregion

        #region Read
        List<Role> ReadRoles();
        List<Role> ReadRoles(string username);
        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion

        #region Other Function

        #endregion
    }
}
