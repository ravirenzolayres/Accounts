using AccountsEntity;
using AccountsModel;
using AutoMapper;

namespace AccountsFunction
{
    public class FAccountBase
    {
        public FAccountBase()
        {
            Mapper.Initialize(a => {
                a.CreateMap<ERole, Role>();
                a.CreateMap<Role, ERole>();
                a.CreateMap<EUser, User>();
                a.CreateMap<User, EUser>();
            });
        }
    }
}
