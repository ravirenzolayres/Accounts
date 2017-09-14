using BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountsEntity
{
    [Table("UserRole")]
    public class EUserRole : EBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public EUser User { get; set; }
        public ERole Role { get; set; }
    }
}
