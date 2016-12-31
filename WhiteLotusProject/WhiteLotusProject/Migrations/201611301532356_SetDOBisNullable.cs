namespace WhiteLotusProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetDOBisNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "DateofBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "DateofBirth", c => c.DateTime(nullable: false));
        }
    }
}
