namespace ContosoData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateStudentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "Id", "dbo.People");
            DropIndex("dbo.Student", new[] { "Id" });
            DropTable("dbo.Student");
        }
    }
}
