using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoModel
{
    [Table("Student")]
    public class Student:People
    {
        public DateTime EnrollmentDate { get; set; }
    }
}
