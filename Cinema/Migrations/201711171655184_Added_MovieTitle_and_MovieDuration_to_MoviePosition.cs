namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_MovieTitle_and_MovieDuration_to_MoviePosition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MoviePosition", "MovieTitle", c => c.String());
            AddColumn("dbo.MoviePosition", "MovieDuration", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MoviePosition", "MovieDuration");
            DropColumn("dbo.MoviePosition", "MovieTitle");
        }
    }
}
