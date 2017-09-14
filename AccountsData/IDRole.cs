using AccountsEntity;
using BaseData;
using System.Collections.Generic;

namespace AccountsData
{
    public interface IDRole : IDBase
    {
        List<ERole> ReadRoles(string username);
    }
}
