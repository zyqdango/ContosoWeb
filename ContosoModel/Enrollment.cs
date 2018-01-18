using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoModel.Common;

namespace ContosoModel
{
    public class Enrollment:AuditableEntity
    {
        public Enrollment()
        {
            CreatedDate = DateTime.Now;
        }
        public int CourseId { get; set; }
        public Course Courses { get; set; }
        public int StudentId { get; set; }
        public Student Students { get; set; }
        public Grade? Grade { get; set; }
    }
    public enum Grade
    {
        A,
        B,
        C,
        D,
        F,
        S,
        US
    }
}
