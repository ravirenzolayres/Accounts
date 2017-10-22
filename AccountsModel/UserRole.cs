using BaseModel;
using System.Collections.Generic;

namespace AccountsModel
{
    public class UserRole : Base
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public int UserRoleId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
    }
}
