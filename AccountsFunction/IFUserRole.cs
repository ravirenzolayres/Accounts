using AccountsModel;
using System.Collections.Generic;

namespace AccountsFunction
{
    public interface IFUserRole
    {
        void Create(List<Role> roles, int userId);

        void Update(List<Role> roles, int userId);
    }
}
