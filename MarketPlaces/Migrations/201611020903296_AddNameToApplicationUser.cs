namespace MarketPlaces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToApplicationUser : DbMigration
    {
        //adding a column to the AspNetUsers table
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
