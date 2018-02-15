namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImagePathToAgeRestrictionModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AgeRestriction", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AgeRestriction", "ImagePath");
        }
    }
}
