using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ContosoModel;

namespace ContosoData
{
    public class ContosoDbContext:DbContext
    {

        public ContosoDbContext():base("name = ContosoDbContext")
        {
                
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseInstructor>().HasKey(sc => new { sc.InstructorId, sc.CourseId });
            modelBuilder.Entity<PersonRole>().HasKey(pr => new { pr.Person_Id, pr.Role_Id });
        }
        
        public DbSet<People> People { get; set; }
        public DbSet<Department> Department{ get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<CourseInstructor> CourseInstructors { get; set; }
        public DbSet<PersonRole> PersonRoles { get; set; }
    }
}
