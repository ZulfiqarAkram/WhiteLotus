namespace WhiteLotusProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReserveWorkshopTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReserveWorkshops",
                c => new
                    {
                        WorkshopId = c.Int(nullable: false),
                        ClientId = c.String(nullable: false, maxLength: 128),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkshopId, t.ClientId })
                .ForeignKey("dbo.AspNetUsers", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Workshops", t => t.WorkshopId, cascadeDelete: true)
                .Index(t => t.WorkshopId)
                .Index(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReserveWorkshops", "WorkshopId", "dbo.Workshops");
            DropForeignKey("dbo.ReserveWorkshops", "ClientId", "dbo.AspNetUsers");
            DropIndex("dbo.ReserveWorkshops", new[] { "ClientId" });
            DropIndex("dbo.ReserveWorkshops", new[] { "WorkshopId" });
            DropTable("dbo.ReserveWorkshops");
        }
    }
}
