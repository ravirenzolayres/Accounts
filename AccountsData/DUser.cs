using AccountsContext;
using AccountsEntity;
using BaseData;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace AccountsData
{
    public class DUser : DBase, IDUser
    {
        public DUser() : base(new Context())
        {

        }

        #region Create
        #endregion

        #region Read
        public List<EUser> Read()
        {
            using (var context = new Context())
            {
                return context.Users
                    .Include(a => a.UserRoles)
                    .Include(a => a.UserRoles.Select(b => b.Role))
                    .OrderBy(a => a.Username)
                    .ToList();
            }
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