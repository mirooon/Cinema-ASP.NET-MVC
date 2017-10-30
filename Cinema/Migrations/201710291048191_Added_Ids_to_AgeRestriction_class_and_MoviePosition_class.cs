namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Ids_to_AgeRestriction_class_and_MoviePosition_class : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.MoviePosition", new[] { "Cinema_Id" });
            DropIndex("dbo.MoviePosition", new[] { "Movie_Id" });
            DropIndex("dbo.MoviePosition", new[] { "MovieType_Id" });
            DropIndex("dbo.Movie", new[] { "AgeRestriction_Id" });
            RenameColumn(table: "dbo.MoviePosition", name: "Cinema_Id", newName: "CinemaId");
            RenameColumn(table: "dbo.MoviePosition", name: "Movie_Id", newName: "MovieId");
            RenameColumn(table: "dbo.MoviePosition", name: "MovieType_Id", newName: "MovieTypeId");
            RenameColumn(table: "dbo.Movie", name: "AgeRestriction_Id", newName: "AgeRestrictionId");
            AlterColumn("dbo.MoviePosition", "CinemaId", c => c.Int(nullable: false));
            AlterColumn("dbo.MoviePosition", "MovieId", c => c.Int(nullable: false));
            AlterColumn("dbo.MoviePosition", "MovieTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Movie", "AgeRestrictionId", c => c.Int(nullable: false));
            CreateIndex("dbo.MoviePosition", "MovieId");
            CreateIndex("dbo.MoviePosition", "MovieTypeId");
            CreateIndex("dbo.MoviePosition", "CinemaId");
            CreateIndex("dbo.Movie", "AgeRestrictionId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Movie", new[] { "AgeRestrictionId" });
            DropIndex("dbo.MoviePosition", new[] { "CinemaId" });
            DropIndex("dbo.MoviePosition", new[] { "MovieTypeId" });
            DropIndex("dbo.MoviePosition", new[] { "MovieId" });
            AlterColumn("dbo.Movie", "AgeRestrictionId", c => c.Int());
            AlterColumn("dbo.MoviePosition", "MovieTypeId", c => c.Int());
            AlterColumn("dbo.MoviePosition", "MovieId", c => c.Int());
            AlterColumn("dbo.MoviePosition", "CinemaId", c => c.Int());
            RenameColumn(table: "dbo.Movie", name: "AgeRestrictionId", newName: "AgeRestriction_Id");
            RenameColumn(table: "dbo.MoviePosition", name: "MovieTypeId", newName: "MovieType_Id");
            RenameColumn(table: "dbo.MoviePosition", name: "MovieId", newName: "Movie_Id");
            RenameColumn(table: "dbo.MoviePosition", name: "CinemaId", newName: "Cinema_Id");
            CreateIndex("dbo.Movie", "AgeRestriction_Id");
            CreateIndex("dbo.MoviePosition", "MovieType_Id");
            CreateIndex("dbo.MoviePosition", "Movie_Id");
            CreateIndex("dbo.MoviePosition", "Cinema_Id");
        }
    }
}
