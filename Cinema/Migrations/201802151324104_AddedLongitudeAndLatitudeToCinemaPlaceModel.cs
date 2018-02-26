namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLongitudeAndLatitudeToCinemaPlaceModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CinemaPlace", "Longitude", c => c.Double(nullable: false));
            AddColumn("dbo.CinemaPlace", "Latitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CinemaPlace", "Latitude");
            DropColumn("dbo.CinemaPlace", "Longitude");
        }
    }
}
