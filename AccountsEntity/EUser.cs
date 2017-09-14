using BaseEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountsEntity
{
    [Table("User")]
    public class EUser: EBase
    {
        //public int EmployeeID;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        [StringLength(50)]
        public string Username { get; set; }
        public int EmployeeId { get; set; }
        [StringLength(50)]
        public string Firstname { get; set; }

        //[StringLength(50)]
        //public string Lastname { get; set; }       
        //[StringLength(50)]
        //public string Middlename { get; set; }
        //[StringLength(50)]
        //public string Department { get; set; }
        //[StringLength(20)]
        //public string Contact { get; set; }
        //[StringLength(50)]
        //public string Email { get; set; }

        public bool Status { get; set; }

        public ICollection<EUserRole> UserRole { get; set; }
    }


}
