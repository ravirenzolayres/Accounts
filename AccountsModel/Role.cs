namespace AccountsModel
{
    public class Role
    {
        private bool? mPreviousRoleStatus { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public bool RoleStatus { get; set; }
        public bool PreviousRoleStatus
        {
            get
            {
                if (mPreviousRoleStatus.HasValue)
                {
                    return mPreviousRoleStatus.Value;
                }
                else
                {
                    return RoleStatus;
                }
            }
            set
            {
                mPreviousRoleStatus = value;
            }
        }
    }
}
