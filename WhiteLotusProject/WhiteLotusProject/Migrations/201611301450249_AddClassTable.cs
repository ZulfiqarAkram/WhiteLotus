namespace WhiteLotusProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Day = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Level = c.String(),
                        Duration = c.String(),
                        Capacity = c.Int(),
                        Description = c.String(),
                        TeacherId = c.Int(nullable: false),
                        IsCanceled = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Classes", new[] { "TeacherId" });
            DropTable("dbo.Classes");
        }
    }
}
