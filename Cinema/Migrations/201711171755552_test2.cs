namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MoviePosition", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MoviePosition", "DateTime", c => c.DateTime(nullable: false));
        }
    }
}
