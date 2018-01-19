namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReplacePhotoRecordWithImagePathInCinemaPlaceAndMovieModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CinemaPlace", "ImagePath", c => c.String());
            AddColumn("dbo.Movie", "ImagePath", c => c.String());
            DropColumn("dbo.CinemaPlace", "Photo");
            DropColumn("dbo.Movie", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movie", "Photo", c => c.Binary());
            AddColumn("dbo.CinemaPlace", "Photo", c => c.Binary());
            DropColumn("dbo.Movie", "ImagePath");
            DropColumn("dbo.CinemaPlace", "ImagePath");
        }
    }
}
