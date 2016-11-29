namespace MarketPlaces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCancelledToMarket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Markets", "IsCancelled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Markets", "IsCancelled");
        }
    }
}
