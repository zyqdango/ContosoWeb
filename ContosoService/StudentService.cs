using ContosoData;
using ContosoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoService
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _studentRepository.GetAll();
        }

        public Student GetStudentByLastName(string lastname)
        {
            return _studentRepository.GetStudentByLastName(lastname);
        }
    }
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentByLastName(string lastname);

    }
}
