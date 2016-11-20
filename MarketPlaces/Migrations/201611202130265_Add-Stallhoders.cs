namespace MarketPlaces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStallhoders : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StallHolders", "Stallholder_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.StallHolders", "Stallholder_Id");
            AddForeignKey("dbo.StallHolders", "Stallholder_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StallHolders", "Stallholder_Id", "dbo.AspNetUsers");
            DropIndex("dbo.StallHolders", new[] { "Stallholder_Id" });
            DropColumn("dbo.StallHolders", "Stallholder_Id");
        }
    }
}
