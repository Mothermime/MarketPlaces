namespace MarketPlaces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTablecolumns : DbMigration
    {
        //making changes to the markets table
        public override void Up()
        {
            AddColumn("dbo.Markets", "Title", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Markets", "MarketName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Markets", "MarketName", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Markets", "Title");
        }
    }
}
