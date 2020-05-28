using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETCoreWithVueJs.Models
{
    public partial class Course
    {
        /*public Course()
        {
            this.Student = new HashSet<Student>();
        }*/

        [Key]
        [Column("PKCourseID")]
        public int PkcourseId { get; set; }
        [Required]
        [StringLength(50)]
        public string CourseName { get; set; }

        //public virtual ICollection<Student> Student { get; set; }
        public ICollection<CoursesStudents> CoursesStudents { get; set; }
    }
}
