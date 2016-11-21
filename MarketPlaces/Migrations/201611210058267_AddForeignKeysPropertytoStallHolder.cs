namespace MarketPlaces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeysPropertytoStallHolder : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.StallHolders", name: "Stallholder_Id", newName: "StallholderId");
            RenameIndex(table: "dbo.StallHolders", name: "IX_Stallholder_Id", newName: "IX_StallholderId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.StallHolders", name: "IX_StallholderId", newName: "IX_Stallholder_Id");
            RenameColumn(table: "dbo.StallHolders", name: "StallholderId", newName: "Stallholder_Id");
        }
    }
}
