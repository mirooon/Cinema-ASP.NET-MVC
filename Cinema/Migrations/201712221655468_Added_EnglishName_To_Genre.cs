namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_EnglishName_To_Genre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genre", "EnglishName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Genre", "EnglishName");
        }
    }
}
