namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgeRestriction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CinemaPlace",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        Name = c.String(),
                        Street = c.String(),
                        Number = c.Int(nullable: false),
                        PostCode = c.Int(nullable: false),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MoviePosition",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Cinema_Id = c.Int(),
                        Movie_Id = c.Int(),
                        MovieType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CinemaPlace", t => t.Cinema_Id)
                .ForeignKey("dbo.Movie", t => t.Movie_Id)
                .ForeignKey("dbo.MovieType", t => t.MovieType_Id)
                .Index(t => t.Cinema_Id)
                .Index(t => t.Movie_Id)
                .Index(t => t.MovieType_Id);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        OryginalTitle = c.String(maxLength: 50),
                        Cast = c.String(maxLength: 100),
                        Director = c.String(maxLength: 50),
                        Production = c.String(maxLength: 50),
                        Premiere = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        Description = c.String(maxLength: 300),
                        TrailerLinkYoutube = c.String(),
                        Photo = c.Binary(),
                        AgeRestriction_Id = c.Int(),
                        MovieType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AgeRestriction", t => t.AgeRestriction_Id)
                .ForeignKey("dbo.MovieType", t => t.MovieType_Id)
                .Index(t => t.AgeRestriction_Id)
                .Index(t => t.MovieType_Id);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(maxLength: 256),
                        City = c.String(),
                        Street = c.String(),
                        Number = c.String(),
                        PostCode = c.String(),
                        Photo = c.Binary(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.GenreMovie",
                c => new
                    {
                        Genre_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_Id, t.Movie_Id })
                .ForeignKey("dbo.Genre", t => t.Genre_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Genre_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.MoviePosition", "MovieType_Id", "dbo.MovieType");
            DropForeignKey("dbo.Movie", "MovieType_Id", "dbo.MovieType");
            DropForeignKey("dbo.MoviePosition", "Movie_Id", "dbo.Movie");
            DropForeignKey("dbo.GenreMovie", "Movie_Id", "dbo.Movie");
            DropForeignKey("dbo.GenreMovie", "Genre_Id", "dbo.Genre");
            DropForeignKey("dbo.Movie", "AgeRestriction_Id", "dbo.AgeRestriction");
            DropForeignKey("dbo.MoviePosition", "Cinema_Id", "dbo.CinemaPlace");
            DropIndex("dbo.GenreMovie", new[] { "Movie_Id" });
            DropIndex("dbo.GenreMovie", new[] { "Genre_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Movie", new[] { "MovieType_Id" });
            DropIndex("dbo.Movie", new[] { "AgeRestriction_Id" });
            DropIndex("dbo.MoviePosition", new[] { "MovieType_Id" });
            DropIndex("dbo.MoviePosition", new[] { "Movie_Id" });
            DropIndex("dbo.MoviePosition", new[] { "Cinema_Id" });
            DropTable("dbo.GenreMovie");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.MovieType");
            DropTable("dbo.Genre");
            DropTable("dbo.Movie");
            DropTable("dbo.MoviePosition");
            DropTable("dbo.CinemaPlace");
            DropTable("dbo.AgeRestriction");
        }
    }
}
