namespace ContosoData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPeopleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "State", c => c.String());
            AddColumn("dbo.People", "ZipCode", c => c.String());
            AddColumn("dbo.People", "PhoneNumber", c => c.String());
            AlterColumn("dbo.People", "CreatedBy", c => c.String());
            AlterColumn("dbo.People", "UpdatedBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.People", "CreatedBy", c => c.Int(nullable: false));
            DropColumn("dbo.People", "PhoneNumber");
            DropColumn("dbo.People", "ZipCode");
            DropColumn("dbo.People", "State");
        }
    }
}
