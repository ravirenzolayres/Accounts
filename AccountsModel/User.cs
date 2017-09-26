using System.Collections.Generic;

namespace AccountsModel
{
    public class User
    {
        public int UserId { get; set; }
        public int EmployeeId { get; set; }

        public string Username { get; set; }
        public string Firstname { get; set; }

        public bool Status { get; set; }

        public List<Role> Roles { get; set; }
    }
}
