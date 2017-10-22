using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountsEntity
{
    [Table("User")]
    public class EUser: EBase
    {
        public bool IsActive { get; set; }

        public int EmployeeId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [StringLength(50)]
        public string Username { get; set; }
        
        public ICollection<EUserRole> UserRoles { get; set; }
    }
}
