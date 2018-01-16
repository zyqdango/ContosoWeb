using ContosoData;
using ContosoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void AddDepartment(Department department)
        {
            _departmentRepository.Add(department);
        }

        public IEnumerable<Department> GetAllDepartmentIncludeCouses()
        {
            return _departmentRepository.GetAllDepartmentIncludeCourses();
        }

        public Department GetDepartmentById(int id)
        {
            return _departmentRepository.GetById(id);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _departmentRepository.GetAll();
        }

        public void UpdateDepartment(Department department)
        {
            _departmentRepository.Update(department);

        }
    }
    public interface IDepartmentService
    {
        IEnumerable<Department> GetDepartments();
        IEnumerable<Department> GetAllDepartmentIncludeCouses();
        Department GetDepartmentById(int id);
        void AddDepartment(Department department);
        void UpdateDepartment(Department department);

    }
}
