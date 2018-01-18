using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoModel
{
    [Table("Instructor")]
    public class Instructor:People
    {
        public Instructor()
        {
            CreatedDate = DateTime.Now;
        }
        public DateTime HireDate { get; set; }
        public Department Department { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }
        public OfficeAssignment OfficeAssignments { get; set; }
    }
}
