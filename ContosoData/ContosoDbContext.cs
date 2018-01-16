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
        public DbSet<People> People { get; set; }
        public DbSet<Department> Department{ get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Student> Student { get; set; }
    }
}
