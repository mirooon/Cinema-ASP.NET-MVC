namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Status_To_MovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movie", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie", "Status");
        }
    }
}
