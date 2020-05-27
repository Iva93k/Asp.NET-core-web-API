using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETCoreWithVueJs.Models
{
    public partial class StudentStatus
    {
        public StudentStatus()
        {
            Student = new HashSet<Student>();
        }

        [Key]
        [Column("PKStudentStatusID")]
        public int PkstudentStatusId { get; set; }
        [Required]
        [StringLength(50)]
        public string StatusName { get; set; }

        [InverseProperty("StudentStatus")]
        public virtual ICollection<Student> Student { get; set; }
    }
}
