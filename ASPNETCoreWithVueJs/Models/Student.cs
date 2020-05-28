using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETCoreWithVueJs.Models
{
    public partial class Student
    {
        /*public Student()
        {
            this.Course = new HashSet<Course>();
        }*/
        [Key]
        [Column("PKStudentID")]
        public int PkstudentId { get; set; }
        [Required]
        [StringLength(50)]
        public string IndexNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        public int Year { get; set; }
        [Column("StudentStatusID")]
        public int StudentStatusId { get; set; }

        [ForeignKey(nameof(StudentStatusId))]
        [InverseProperty("Student")]
        public virtual StudentStatus StudentStatus { get; set; }

        public ICollection<CoursesStudents> CoursesStudents { get; set; }

        //public virtual ICollection<Course> Course { get; set; }

    }
}
