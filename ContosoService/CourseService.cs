using ContosoData;
using ContosoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoService
{
    public class CourseService : ICourseService
    {
        private readonly CourseRepository _courseRepository;
        public CourseService(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void AddCourse(Course course)
        {
            _courseRepository.Add(course);
            _courseRepository.SaveChanges();
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _courseRepository.GetAll();
        }

        public Course GetCourseById(int id)
        {
            return _courseRepository.GetById(id);
        }

        public void UpdateCourse(Course course)
        {
            _courseRepository.Update(course);
            _courseRepository.SaveChanges();
        }
    }
    public interface ICourseService
    {
        IEnumerable<Course> GetAllCourses();
        Course GetCourseById(int id);
        void UpdateCourse(Course course);
        void AddCourse(Course course);
    }
}
