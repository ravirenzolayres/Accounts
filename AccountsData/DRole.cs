using AccountsContext;
using AccountsEntity;
using BaseData;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccountsData
{
    public class DRole : DBase, IDRole
    {
        public DRole() : base(new Context())
        {
        }
        #region Create

        #endregion

        #region Read
        public List<ERole> ReadRoles(string username)
        {
            using (var context = new Context())
            {
                return context.Roles
                    .Include(a => a.UserRole)
                    .Include(a => a.UserRole.Select(b => b.User))
                    .Where(a => a.UserRole.Any(b => b.User.Username == username))
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
