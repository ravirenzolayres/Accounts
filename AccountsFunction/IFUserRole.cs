using AccountsModel;
using System.Collections.Generic;

namespace AccountsFunction
{
    public interface IFUserRole
    {
        void Create(int createdBy, int userId, List<UserRole> userRoles);
    }
}
