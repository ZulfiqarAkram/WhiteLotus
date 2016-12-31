namespace WhiteLotusProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorkshopTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Workshops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Duration = c.String(),
                        Venue = c.String(),
                        TeacherId = c.Int(nullable: false),
                        IsCanceled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workshops", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Workshops", new[] { "TeacherId" });
            DropTable("dbo.Workshops");
        }
    }
}
