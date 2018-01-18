using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoModel.Common;

namespace ContosoModel
{
    public class Role:AuditableEntity
    {
        public string RoleName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<PersonRole> PersonRoles { get; set; }

    }
}
