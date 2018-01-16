namespace ContosoData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDbMigratin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        LastName = c.String(),
                        MiddelName = c.String(),
                        Email = c.String(),
                        City = c.String(),
                        DateBirth = c.DateTime(),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
        }
    }
}
