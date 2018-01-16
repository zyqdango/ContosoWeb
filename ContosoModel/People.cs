using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoModel.Common;

namespace ContosoModel
{
    public class People: AuditableEntity
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string MiddelName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public DateTime? DateBirth { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
