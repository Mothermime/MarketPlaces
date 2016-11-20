namespace MarketPlaces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideStallholder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StallHolders", "Stallholder_Id", "dbo.AspNetUsers");
            DropIndex("dbo.StallHolders", new[] { "Stallholder_Id" });
            AlterColumn("dbo.StallHolders", "Name", c => c.String(nullable: false, maxLength: 225));
            AlterColumn("dbo.StallHolders", "Product", c => c.String(nullable: false, maxLength: 225));
            AlterColumn("dbo.StallHolders", "Stallholder_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.StallHolders", "Stallholder_Id");
            AddForeignKey("dbo.StallHolders", "Stallholder_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StallHolders", "Stallholder_Id", "dbo.AspNetUsers");
            DropIndex("dbo.StallHolders", new[] { "Stallholder_Id" });
            AlterColumn("dbo.StallHolders", "Stallholder_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.StallHolders", "Product", c => c.String());
            AlterColumn("dbo.StallHolders", "Name", c => c.String());
            CreateIndex("dbo.StallHolders", "Stallholder_Id");
            AddForeignKey("dbo.StallHolders", "Stallholder_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
