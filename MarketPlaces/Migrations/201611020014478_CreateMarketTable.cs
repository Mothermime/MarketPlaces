namespace MarketPlaces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMarketTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Markets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganiserId = c.String(nullable: false, maxLength: 128),
                        MarketName = c.String(nullable: false, maxLength: 255),
                        DateTime = c.DateTime(nullable: false),
                        Venue = c.String(nullable: false, maxLength: 255),
                        CategoryId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.OrganiserId, cascadeDelete: true)
                .Index(t => t.OrganiserId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Markets", "OrganiserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Markets", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Markets", new[] { "CategoryId" });
            DropIndex("dbo.Markets", new[] { "OrganiserId" });
            DropTable("dbo.Markets");
            DropTable("dbo.Categories");
        }
    }
}
