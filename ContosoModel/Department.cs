using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoModel.Common;

namespace ContosoModel
{
    public class Department:AuditableEntity
    {
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartTime { get; set; }
        public ICollection<Course> Course{ get; set; }
    }
}
