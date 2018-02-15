namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAgeRestrictionImagePathToMoviePositionModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MoviePosition", "AgeRestrictionImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MoviePosition", "AgeRestrictionImagePath");
        }
    }
}
