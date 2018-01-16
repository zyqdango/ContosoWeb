using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoModel.Common
{
    public interface IAuditableEntity
    {
        DateTime? CreatedDate { get; set; }//nullable type
        DateTime? UpdatedDate { get; set; }
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
    }
}
