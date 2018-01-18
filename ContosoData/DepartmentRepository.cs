using ContosoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ContosoData
{
    public class DepartmentRepository:Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ContosoDbContext context) : base(context)
        {
        }
        public IEnumerable<Department> GetAllDepartmentIncludeCourses()
        {
            var departments = _context.Department.Include(d => d.Courses).ToList();
            return departments;
        }
       
    }
    public interface IDepartmentRepository : IRepository<Department>
    {
        IEnumerable<Department> GetAllDepartmentIncludeCourses();
    }
}
