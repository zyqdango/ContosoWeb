using ContosoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoData
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(ContosoDbContext context) : base(context)
        {
        }

        public Student GetStudentByLastName(string lastname)
        {
            var student = _context.People.OfType<Student>().FirstOrDefault(s => s.LastName == lastname);
            return student;
        }
    }

    public interface IStudentRepository:IRepository<Student>
    {
        Student GetStudentByLastName(string lastname);
    }
}
