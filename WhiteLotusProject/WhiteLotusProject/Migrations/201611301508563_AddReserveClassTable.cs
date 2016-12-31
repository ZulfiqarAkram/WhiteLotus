namespace WhiteLotusProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReserveClassTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReserveClasses",
                c => new
                    {
                        ClassId = c.Int(nullable: false),
                        ClientId = c.String(nullable: false, maxLength: 128),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClassId, t.ClientId })
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClassId)
                .Index(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReserveClasses", "ClientId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReserveClasses", "ClassId", "dbo.Classes");
            DropIndex("dbo.ReserveClasses", new[] { "ClientId" });
            DropIndex("dbo.ReserveClasses", new[] { "ClassId" });
            DropTable("dbo.ReserveClasses");
        }
    }
}
