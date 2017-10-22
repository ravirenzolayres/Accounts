using BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountsEntity
{
    [Table("UserRole")]
    public class EUserRole : EBase
    {
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserRoleId { get; set; }

        public EUser User { get; set; }
        public ERole Role { get; set; }
    }
}
