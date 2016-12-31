namespace WhiteLotusProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertiesinApplicationUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DateofBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "YogaExperience", c => c.String(maxLength: 255));
            AddColumn("dbo.AspNetUsers", "HealthIssues", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "HealthIssues");
            DropColumn("dbo.AspNetUsers", "YogaExperience");
            DropColumn("dbo.AspNetUsers", "DateofBirth");
        }
    }
}
