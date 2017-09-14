using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountsEntity
{
    [Table("Role")]
    public class ERole : EBase
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RoleID { get; set; }
        [StringLength(20)]
        public string RoleName { get; set; }

        public ICollection<EUserRole> UserRole { get; set; }
    }
}
