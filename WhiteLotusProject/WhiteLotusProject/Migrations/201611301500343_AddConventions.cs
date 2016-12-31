namespace WhiteLotusProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConventions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Classes", "Title", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Classes", "Day", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Teachers", "Email", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Teachers", "MobileNo", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "MobileNo", c => c.String());
            AlterColumn("dbo.Teachers", "Email", c => c.String());
            AlterColumn("dbo.Teachers", "Name", c => c.String());
            AlterColumn("dbo.Classes", "Day", c => c.String());
            AlterColumn("dbo.Classes", "Title", c => c.String());
        }
    }
}
