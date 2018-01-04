namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_EnglishName_To_AgeRestriction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AgeRestriction", "EnglishName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AgeRestriction", "EnglishName");
        }
    }
}
