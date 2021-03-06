namespace AddressBook.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RenameCoords : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "Location", c => c.Geography());
            DropColumn("dbo.Addresses", "Coords");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "Coords", c => c.Geography());
            DropColumn("dbo.Addresses", "Location");
        }
    }
}
