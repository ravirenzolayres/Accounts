using AccountsEntity;
using BaseData;
using System.Collections.Generic;

namespace AccountsData
{
    public interface IDUser : IDBase
    {
        bool IsMethodAccessible(string Username, List<string> AllowedRoles);
        bool IsUserExist(string Username);
        List<EUser> ReadUsers();
        List<EUser> ReadUsers(string username);
    }
}