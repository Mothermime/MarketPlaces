namespace MarketPlaces.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateCategoryTable : DbMigration
    {
        //This migration started as a blank migration and then the sql statements populated it.  Whenver the up method is changed, update the down method to match.  Down method needs to be the opposite of the up method.
        //If any more categories are needed a new migration can always be created
        public override void Up()
        {
            Sql("INSERT Into Categories (Id, Name) Values (1, 'General')");
            Sql("INSERT Into Categories (Id, Name) Values (2, 'Craft')");
            Sql("INSERT Into Categories (Id, Name) Values (3, 'Farmers')");
            Sql("INSERT Into Categories (Id, Name) Values (4, 'School Fair')");
            Sql("INSERT Into Categories (Id, Name) Values (5, 'Antiques')");
            Sql("INSERT Into Categories (Id, Name) Values (6, 'Twilight')");
            Sql("INSERT Into Categories (Id, Name) Values (7, 'Medieval')");
            Sql("INSERT Into Categories (Id, Name) Values (8, 'Community')");
            Sql("INSERT Into Categories (Id, Name) Values (9, 'Car Boot Sale')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Categories WHERE Id IN (1,2,3,4,5,6,7,8,9)");
        }
    }
}
