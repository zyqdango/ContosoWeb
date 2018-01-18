using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoModel.Common;

namespace ContosoModel
{
    public class OfficeAssignment:AuditableEntity
    {
        public int InstructorId { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
        [MaxLength(150)]
        public string Location { get; set; }
    }
}
