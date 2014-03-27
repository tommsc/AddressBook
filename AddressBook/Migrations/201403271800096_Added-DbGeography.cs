namespace AddressBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class AddedDbGeography : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "Name", c => c.String());
            AddColumn("dbo.Addresses", "Coords", c => c.Geography());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Addresses", "Coords");
            DropColumn("dbo.Addresses", "Name");
        }
    }
}
