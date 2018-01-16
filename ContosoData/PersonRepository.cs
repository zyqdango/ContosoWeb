using ContosoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoData
{
    public class PersonRepository : Repository<People>, IPersonRepository
    {
        
        public PersonRepository(ContosoDbContext context) : base(context)
        {

        }
        public People GetByLastName(string name)
        {
            var person = _context.People.Where(p => p.LastName == name).FirstOrDefault();
            return person;
        }
    }
    public interface IPersonRepository : IRepository<People>
    {
    }


}
