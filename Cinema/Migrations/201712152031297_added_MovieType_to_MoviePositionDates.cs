namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_MovieType_to_MoviePositionDates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MoviePositionDates", "MovieTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.MoviePositionDates", "MoviePositionId");
            CreateIndex("dbo.MoviePositionDates", "MovieTypeId");
            AddForeignKey("dbo.MoviePositionDates", "MoviePositionId", "dbo.MoviePosition", "Id");
            AddForeignKey("dbo.MoviePositionDates", "MovieTypeId", "dbo.MovieType", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MoviePositionDates", "MovieTypeId", "dbo.MovieType");
            DropForeignKey("dbo.MoviePositionDates", "MoviePositionId", "dbo.MoviePosition");
            DropIndex("dbo.MoviePositionDates", new[] { "MovieTypeId" });
            DropIndex("dbo.MoviePositionDates", new[] { "MoviePositionId" });
            DropColumn("dbo.MoviePositionDates", "MovieTypeId");
        }
    }
}
