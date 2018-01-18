namespace ContosoData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyAndMoveFaultTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseInstructorCourses", new[] { "CourseInstructor_InstructorId", "CourseInstructor_CourseId" }, "dbo.CourseInstructors");
            DropForeignKey("dbo.CourseInstructorCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.InstructorCourseInstructors", "Instructor_Id", "dbo.Instructor");
            DropForeignKey("dbo.InstructorCourseInstructors", new[] { "CourseInstructor_InstructorId", "CourseInstructor_CourseId" }, "dbo.CourseInstructors");
            DropForeignKey("dbo.PeoplePersonRoles", "People_Id", "dbo.People");
            DropForeignKey("dbo.PeoplePersonRoles", new[] { "PersonRole_Person_Id", "PersonRole_Role_Id" }, "dbo.PersonRoles");
            DropForeignKey("dbo.RolePersonRoles", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.RolePersonRoles", new[] { "PersonRole_Person_Id", "PersonRole_Role_Id" }, "dbo.PersonRoles");
            DropIndex("dbo.CourseInstructorCourses", new[] { "CourseInstructor_InstructorId", "CourseInstructor_CourseId" });
            DropIndex("dbo.CourseInstructorCourses", new[] { "Course_Id" });
            DropIndex("dbo.InstructorCourseInstructors", new[] { "Instructor_Id" });
            DropIndex("dbo.InstructorCourseInstructors", new[] { "CourseInstructor_InstructorId", "CourseInstructor_CourseId" });
            DropIndex("dbo.PeoplePersonRoles", new[] { "People_Id" });
            DropIndex("dbo.PeoplePersonRoles", new[] { "PersonRole_Person_Id", "PersonRole_Role_Id" });
            DropIndex("dbo.RolePersonRoles", new[] { "Role_Id" });
            DropIndex("dbo.RolePersonRoles", new[] { "PersonRole_Person_Id", "PersonRole_Role_Id" });
            AddColumn("dbo.PersonRoles", "People_Id", c => c.Int());
            AddColumn("dbo.PersonRoles", "Role_Id1", c => c.Int());
            CreateIndex("dbo.CourseInstructors", "InstructorId");
            CreateIndex("dbo.CourseInstructors", "CourseId");
            CreateIndex("dbo.PersonRoles", "People_Id");
            CreateIndex("dbo.PersonRoles", "Role_Id1");
            AddForeignKey("dbo.CourseInstructors", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CourseInstructors", "InstructorId", "dbo.Instructor", "Id");
            AddForeignKey("dbo.PersonRoles", "People_Id", "dbo.People", "Id");
            AddForeignKey("dbo.PersonRoles", "Role_Id1", "dbo.Roles", "Id");
            DropTable("dbo.CourseInstructorCourses");
            DropTable("dbo.InstructorCourseInstructors");
            DropTable("dbo.PeoplePersonRoles");
            DropTable("dbo.RolePersonRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RolePersonRoles",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        PersonRole_Person_Id = c.Int(nullable: false),
                        PersonRole_Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.PersonRole_Person_Id, t.PersonRole_Role_Id });
            
            CreateTable(
                "dbo.PeoplePersonRoles",
                c => new
                    {
                        People_Id = c.Int(nullable: false),
                        PersonRole_Person_Id = c.Int(nullable: false),
                        PersonRole_Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.People_Id, t.PersonRole_Person_Id, t.PersonRole_Role_Id });
            
            CreateTable(
                "dbo.InstructorCourseInstructors",
                c => new
                    {
                        Instructor_Id = c.Int(nullable: false),
                        CourseInstructor_InstructorId = c.Int(nullable: false),
                        CourseInstructor_CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Instructor_Id, t.CourseInstructor_InstructorId, t.CourseInstructor_CourseId });
            
            CreateTable(
                "dbo.CourseInstructorCourses",
                c => new
                    {
                        CourseInstructor_InstructorId = c.Int(nullable: false),
                        CourseInstructor_CourseId = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseInstructor_InstructorId, t.CourseInstructor_CourseId, t.Course_Id });
            
            DropForeignKey("dbo.PersonRoles", "Role_Id1", "dbo.Roles");
            DropForeignKey("dbo.PersonRoles", "People_Id", "dbo.People");
            DropForeignKey("dbo.CourseInstructors", "InstructorId", "dbo.Instructor");
            DropForeignKey("dbo.CourseInstructors", "CourseId", "dbo.Courses");
            DropIndex("dbo.PersonRoles", new[] { "Role_Id1" });
            DropIndex("dbo.PersonRoles", new[] { "People_Id" });
            DropIndex("dbo.CourseInstructors", new[] { "CourseId" });
            DropIndex("dbo.CourseInstructors", new[] { "InstructorId" });
            DropColumn("dbo.PersonRoles", "Role_Id1");
            DropColumn("dbo.PersonRoles", "People_Id");
            CreateIndex("dbo.RolePersonRoles", new[] { "PersonRole_Person_Id", "PersonRole_Role_Id" });
            CreateIndex("dbo.RolePersonRoles", "Role_Id");
            CreateIndex("dbo.PeoplePersonRoles", new[] { "PersonRole_Person_Id", "PersonRole_Role_Id" });
            CreateIndex("dbo.PeoplePersonRoles", "People_Id");
            CreateIndex("dbo.InstructorCourseInstructors", new[] { "CourseInstructor_InstructorId", "CourseInstructor_CourseId" });
            CreateIndex("dbo.InstructorCourseInstructors", "Instructor_Id");
            CreateIndex("dbo.CourseInstructorCourses", "Course_Id");
            CreateIndex("dbo.CourseInstructorCourses", new[] { "CourseInstructor_InstructorId", "CourseInstructor_CourseId" });
            AddForeignKey("dbo.RolePersonRoles", new[] { "PersonRole_Person_Id", "PersonRole_Role_Id" }, "dbo.PersonRoles", new[] { "Person_Id", "Role_Id" }, cascadeDelete: true);
            AddForeignKey("dbo.RolePersonRoles", "Role_Id", "dbo.Roles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PeoplePersonRoles", new[] { "PersonRole_Person_Id", "PersonRole_Role_Id" }, "dbo.PersonRoles", new[] { "Person_Id", "Role_Id" }, cascadeDelete: true);
            AddForeignKey("dbo.PeoplePersonRoles", "People_Id", "dbo.People", "Id", cascadeDelete: true);
            AddForeignKey("dbo.InstructorCourseInstructors", new[] { "CourseInstructor_InstructorId", "CourseInstructor_CourseId" }, "dbo.CourseInstructors", new[] { "InstructorId", "CourseId" }, cascadeDelete: true);
            AddForeignKey("dbo.InstructorCourseInstructors", "Instructor_Id", "dbo.Instructor", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CourseInstructorCourses", "Course_Id", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CourseInstructorCourses", new[] { "CourseInstructor_InstructorId", "CourseInstructor_CourseId" }, "dbo.CourseInstructors", new[] { "InstructorId", "CourseId" }, cascadeDelete: true);
        }
    }
}
