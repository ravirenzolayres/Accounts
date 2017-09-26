using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountsEntity
{
    [Table("User")]
    public class EUser: EBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [StringLength(50)]
        public string Username { get; set; }
        public int EmployeeId { get; set; }
        [StringLength(50)]
        public string Firstname { get; set; }

        public bool Status { get; set; }

        public ICollection<EUserRole> UserRole { get; set; }
    }


}
