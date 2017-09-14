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
        public bool IsMethodAccessible(string Username, List<string> AllowedRoles)
        {
            using (var context = new Context())
            {
                return context.Users
                    .Include(a => a.UserRole)
                    .Include(a => a.UserRole.Select(b => b.Role))
                    .Any(a => a.Username == Username && a.Status &&
                            a.UserRole.Select(b => b.Role).Any(c => AllowedRoles.Contains(c.RoleName)));
            }
        }

        public bool IsUserExist(string Username)
        {
            using (var context = new Context())
            {
                return context.Users
                    .Any(a => a.Username == Username && a.Status);
            }
        }

        public List<EUser> ReadUsers()
        {
            using (var context = new Context())
            {
                return context.Users
                    .Include(a => a.UserRole)
                    .Include(a => a.UserRole.Select(b => b.Role))
                    .ToList();
            }
        }

        public List<EUser> ReadUsers(string username)
        {
            using (var context = new Context())
            {
                return context.Users
                    .Include(a => a.UserRole)
                    .Include(a => a.UserRole.Select(b => b.Role))
                    .Where(a => a.Username == username)
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