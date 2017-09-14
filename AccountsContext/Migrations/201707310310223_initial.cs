namespace AccountsContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "EmployeeId", c => c.Int(nullable: false));
            DropColumn("dbo.User", "Lastname");
            DropColumn("dbo.User", "Middlename");
            DropColumn("dbo.User", "Department");
            DropColumn("dbo.User", "Contact");
            DropColumn("dbo.User", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Email", c => c.String(maxLength: 50));
            AddColumn("dbo.User", "Contact", c => c.String(maxLength: 20));
            AddColumn("dbo.User", "Department", c => c.String(maxLength: 50));
            AddColumn("dbo.User", "Middlename", c => c.String(maxLength: 50));
            AddColumn("dbo.User", "Lastname", c => c.String(maxLength: 50));
            DropColumn("dbo.User", "EmployeeId");
        }
    }
}
