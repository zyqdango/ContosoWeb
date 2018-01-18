namespace ContosoData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSomeTablesToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseInstructors",
                c => new
                    {
                        InstructorId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.InstructorId, t.CourseId });
            
            CreateTable(
                "dbo.OfficeAssignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InstructorId = c.Int(nullable: false),
                        Location = c.String(maxLength: 150),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonRoles",
                c => new
                    {
                        Person_Id = c.Int(nullable: false),
                        Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Role_Id });
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Grade = c.Int(),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.CourseInstructorCourses",
                c => new
                    {
                        CourseInstructor_InstructorId = c.Int(nullable: false),
                        CourseInstructor_CourseId = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseInstructor_InstructorId, t.CourseInstructor_CourseId, t.Course_Id })
                .ForeignKey("dbo.CourseInstructors", t => new { t.CourseInstructor_InstructorId, t.CourseInstructor_CourseId }, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => new { t.CourseInstructor_InstructorId, t.CourseInstructor_CourseId })
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.InstructorCourseInstructors",
                c => new
                    {
                        Instructor_Id = c.Int(nullable: false),
                        CourseInstructor_InstructorId = c.Int(nullable: false),
                        CourseInstructor_CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Instructor_Id, t.CourseInstructor_InstructorId, t.CourseInstructor_CourseId })
                .ForeignKey("dbo.Instructor", t => t.Instructor_Id, cascadeDelete: true)
                .ForeignKey("dbo.CourseInstructors", t => new { t.CourseInstructor_InstructorId, t.CourseInstructor_CourseId }, cascadeDelete: true)
                .Index(t => t.Instructor_Id)
                .Index(t => new { t.CourseInstructor_InstructorId, t.CourseInstructor_CourseId });
            
            CreateTable(
                "dbo.PeoplePersonRoles",
                c => new
                    {
                        People_Id = c.Int(nullable: false),
                        PersonRole_Person_Id = c.Int(nullable: false),
                        PersonRole_Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.People_Id, t.PersonRole_Person_Id, t.PersonRole_Role_Id })
                .ForeignKey("dbo.People", t => t.People_Id, cascadeDelete: true)
                .ForeignKey("dbo.PersonRoles", t => new { t.PersonRole_Person_Id, t.PersonRole_Role_Id }, cascadeDelete: true)
                .Index(t => t.People_Id)
                .Index(t => new { t.PersonRole_Person_Id, t.PersonRole_Role_Id });
            
            CreateTable(
                "dbo.RolePersonRoles",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        PersonRole_Person_Id = c.Int(nullable: false),
                        PersonRole_Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.PersonRole_Person_Id, t.PersonRole_Role_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.PersonRoles", t => new { t.PersonRole_Person_Id, t.PersonRole_Role_Id }, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => new { t.PersonRole_Person_Id, t.PersonRole_Role_Id });
            
            CreateTable(
                "dbo.Instructor",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Department_Id = c.Int(),
                        OfficeAssignments_Id = c.Int(),
                        HireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .ForeignKey("dbo.OfficeAssignments", t => t.OfficeAssignments_Id)
                .Index(t => t.Id)
                .Index(t => t.Department_Id)
                .Index(t => t.OfficeAssignments_Id);
            
            AddColumn("dbo.Departments", "InstructorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Departments", "StartTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Instructor", "OfficeAssignments_Id", "dbo.OfficeAssignments");
            DropForeignKey("dbo.Instructor", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.Instructor", "Id", "dbo.People");
            DropForeignKey("dbo.Enrollments", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.RolePersonRoles", new[] { "PersonRole_Person_Id", "PersonRole_Role_Id" }, "dbo.PersonRoles");
            DropForeignKey("dbo.RolePersonRoles", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.PeoplePersonRoles", new[] { "PersonRole_Person_Id", "PersonRole_Role_Id" }, "dbo.PersonRoles");
            DropForeignKey("dbo.PeoplePersonRoles", "People_Id", "dbo.People");
            DropForeignKey("dbo.InstructorCourseInstructors", new[] { "CourseInstructor_InstructorId", "CourseInstructor_CourseId" }, "dbo.CourseInstructors");
            DropForeignKey("dbo.InstructorCourseInstructors", "Instructor_Id", "dbo.Instructor");
            DropForeignKey("dbo.CourseInstructorCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.CourseInstructorCourses", new[] { "CourseInstructor_InstructorId", "CourseInstructor_CourseId" }, "dbo.CourseInstructors");
            DropIndex("dbo.Instructor", new[] { "OfficeAssignments_Id" });
            DropIndex("dbo.Instructor", new[] { "Department_Id" });
            DropIndex("dbo.Instructor", new[] { "Id" });
            DropIndex("dbo.RolePersonRoles", new[] { "PersonRole_Person_Id", "PersonRole_Role_Id" });
            DropIndex("dbo.RolePersonRoles", new[] { "Role_Id" });
            DropIndex("dbo.PeoplePersonRoles", new[] { "PersonRole_Person_Id", "PersonRole_Role_Id" });
            DropIndex("dbo.PeoplePersonRoles", new[] { "People_Id" });
            DropIndex("dbo.InstructorCourseInstructors", new[] { "CourseInstructor_InstructorId", "CourseInstructor_CourseId" });
            DropIndex("dbo.InstructorCourseInstructors", new[] { "Instructor_Id" });
            DropIndex("dbo.CourseInstructorCourses", new[] { "Course_Id" });
            DropIndex("dbo.CourseInstructorCourses", new[] { "CourseInstructor_InstructorId", "CourseInstructor_CourseId" });
            DropIndex("dbo.Enrollments", new[] { "StudentId" });
            DropIndex("dbo.Enrollments", new[] { "CourseId" });
            AlterColumn("dbo.Departments", "StartTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Departments", "InstructorId");
            DropTable("dbo.Instructor");
            DropTable("dbo.RolePersonRoles");
            DropTable("dbo.PeoplePersonRoles");
            DropTable("dbo.InstructorCourseInstructors");
            DropTable("dbo.CourseInstructorCourses");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Roles");
            DropTable("dbo.PersonRoles");
            DropTable("dbo.OfficeAssignments");
            DropTable("dbo.CourseInstructors");
        }
    }
}
