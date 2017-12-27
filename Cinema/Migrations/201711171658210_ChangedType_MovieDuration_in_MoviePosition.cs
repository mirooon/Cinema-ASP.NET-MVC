namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedType_MovieDuration_in_MoviePosition : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MoviePosition", "MovieDuration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MoviePosition", "MovieDuration", c => c.String());
        }
    }
}
