namespace Cinema.Migrations
{
    using Cinema.Context;
    using Cinema.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Cinema.Context.CinemaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Cinema.Context.CinemaDbContext context)
        {
            SeedGenres(context);
            SeedAgesRestriction(context);
            SeedMovieTypes(context);
            SeedCinemas(context);
            SeedMovies(context);
            SeedPositions(context);
            SeedPositionsDates(context);
            SeedBanners(context);
            SeedEvents(context);
            SeedNews(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
        private void SeedGenres(CinemaDbContext context)
        {
            var genres = new List<Genre>{
                new Genre { Id = 1, EnglishName = "Action" , Name = "Akcja"},
                new Genre { Id = 2, EnglishName = "Biographical", Name = "Biograficzne" },
                new Genre { Id = 3, EnglishName = "Documentary", Name = "Dokumentalne" },
                new Genre { Id = 4, EnglishName = "Drama", Name = "Dramat" },
                new Genre { Id = 5, EnglishName = "Family", Name = "Familijne" },
                new Genre { Id = 6, EnglishName = "Horror", Name = "Horror" },
                new Genre { Id = 7, EnglishName = "Comedy" , Name = "Komedie"},
                new Genre { Id = 8, EnglishName = "Musical", Name = "Musical" },
                new Genre { Id = 9, EnglishName = "Sci-Fi" , Name = "Sci-Fi"},
                new Genre { Id = 10, EnglishName = "Thriller", Name = "Thriller" }
            };
            genres.ForEach(g => context.Genres.AddOrUpdate(p => p.Name, g));
            context.SaveChanges();
        }
        private void SeedAgesRestriction(CinemaDbContext context)
        {
            var ages = new List<AgeRestriction>{
                new AgeRestriction { Id = 1, Name = "Wiek 6+", EnglishName = "Age 6+", ImagePath="~/Content/images/age6_.png" },
                new AgeRestriction { Id = 2, Name = "Wiek 15+", EnglishName = "Age 15+", ImagePath="~/Content/images/age15_.png" },
                new AgeRestriction { Id = 3, Name = "Wiek 18+", EnglishName = "Age 18+", ImagePath="~/Content/images/age18_.png" },
                new AgeRestriction { Id = 4, Name = "Brak ograniczeń wiekowych", EnglishName = "Age NoLimit", ImagePath="~/Content/images/ageNoLimit.png" },
                new AgeRestriction { Id = 5, Name = "Wiek nieznany", EnglishName = "Age unknown", ImagePath="~/Content/images/ageUNKNOWN.png" }, 
                };
            ages.ForEach(g => context.AgesRestriction.AddOrUpdate(g));
            context.SaveChanges();
        }
        private void SeedMovieTypes(CinemaDbContext context)
        {
            var movietypes = new List<MovieType>{
                new MovieType { Id = 1, Name="2D" },
                new MovieType { Id = 2, Name="3D" },
                new MovieType { Id = 3, Name="Dubbing" },
                new MovieType { Id = 4, Name="Lector EN" },
                new MovieType { Id = 5, Name="Lector PL" },
                new MovieType { Id = 6, Name="Lyrics EN" },
                new MovieType { Id = 7, Name="Lyrics PL" },
                new MovieType { Id = 8, Name="IMAX" },
            };
            movietypes.ForEach(g => context.MovieTypes.AddOrUpdate(p => p.Name, g));
            context.SaveChanges();
        }
        private void SeedCinemas(CinemaDbContext context)
        {
            context.Cinemas.AddOrUpdate(new CinemaPlace { Id = 1, City = "Bydgoszcz", Name = "FocusMall", Street = "Jagiello", Number = 39, PostCode = 85 - 094, Longitude= 18.01774398, Latitude= 53.12441802 });
            context.Cinemas.AddOrUpdate(new CinemaPlace { Id = 2, City = "Bydgoszcz", Name = "Galeria Pomorska", Street = "Fordońska", Number = 141, PostCode = 85 - 739,Longitude = 18.06728116, Latitude = 53.12512106 });
            context.Cinemas.AddOrUpdate(new CinemaPlace { Id = 3, City = "Poznań", Name = "Posnania", Street = "Pleszewska ", Number = 1, PostCode = 61 - 136, Longitude = 16.95501018, Latitude = 52.39709315 });
            context.SaveChanges();
        }
        private void SeedMovies(CinemaDbContext context)
        {
            CinemaDbContext db = new CinemaDbContext();

            var movies = new List<Movie>{
                new Movie { Id = 1, Title="Król Artur: Legenda miecza" , OryginalTitle="King Arthur: Legend of the Sword", Description="Młody Artur zdobywa miecz Excalibur i wiedzę na temat swojego królewskiego pochodzenia. Przyłącza się do rebelii, aby pokonać tyrana, który zamordował jego rodziców.", Duration=126, Premiere= new DateTime(2017,6,16), Director="Guy Ritchie", Cast="Charlie Hunnam, Astrid Bergès-Frisbey, Jude Law", Production="CUSA 2017", AgeRestrictionId=3  ,TrailerLinkYoutube = "https://www.youtube.com/watch?v=40wycr0oMYA", Status = Status.NowBooking, GenreId = 3, ImagePath = "~/Content/images/arthurposter185337101.jpg"}, 
                new Movie { Id = 2, Title="Skyfall", OryginalTitle="Skyfall", Description="Lojalność agenta 007 wobec M zostaje wystawiona na próbę po ataku na siedzibę MI6 i kradzieży tajnych danych. Trop wiedzie do osoby z przeszłości szefowej brytyjskiego wywiadu. ", Duration=143, Premiere= new DateTime(2012,10,26), Director="Sam Mendes", Cast="Daniel Craig, Judi Dench, Javier Bardem", Production="Metro-Goldwyn-Mayer", AgeRestrictionId=2, TrailerLinkYoutube = "https://www.youtube.com/watch?v=6kw1UVovByw", Status = Status.Soon, GenreId = 3, ImagePath = "~/Content/images/skyfallposter185356093.jpg"},
                new Movie { Id = 3, Title="X-Men", OryginalTitle="X-Men", Description="Ekranizacja popularnej serii komiksów o obdarzonych nadnaturalnymi zdolnościami mutantach. Schronienie przed prześladowaniami ze strony ludzi znajdują w specjalnej szkole profesora Charlesa Xaviera.", Duration=102, Premiere= new DateTime(2000,10,13), Director="Bryan Singer", Cast="Hugh Jackman, Patrick Stewart, Ian McKellen", Production="Lauren Shuler Donner", AgeRestrictionId=4 , TrailerLinkYoutube = "https://www.youtube.com/watch?v=Iy5R5_T243w", Status = Status.NowBooking, GenreId = 3, ImagePath = "~/Content/images/xmenposter185410100.jpg" }
            };
            movies.ForEach(g => context.Movies.AddOrUpdate(p => p.Title, g));
            context.SaveChanges();
        }
        private void SeedPositions(CinemaDbContext context)
        {
            CinemaDbContext db = new CinemaDbContext();

            var positions = new List<MoviePosition>{
               new MoviePosition { Id = 1, CinemaId=1, MovieId=2 },
               new MoviePosition { Id = 2, CinemaId=1, MovieId=3 },
               new MoviePosition { Id = 3, CinemaId=2, MovieId=3 },
            };
            positions.ForEach(g => context.MoviePositions.AddOrUpdate(a=>a.Id,g));
            context.SaveChanges();
        }
        private void SeedPositionsDates(CinemaDbContext context)
        {
            CinemaDbContext db = new CinemaDbContext();

            var positions = new List<MoviePositionDates>{
                new MoviePositionDates {  Id = 1, MoviePositionId = 1,MovieTypeId = 3, DateTime = new DateTime(2018,02,13,11,30,00)},
                new MoviePositionDates {  Id = 2, MoviePositionId = 1,MovieTypeId = 3, DateTime = new DateTime(2018,02,13,12,30,00)},
                new MoviePositionDates {  Id = 3, MoviePositionId = 1,MovieTypeId = 3, DateTime = new DateTime(2018,02,13,13,30,00) },
                new MoviePositionDates {  Id = 4, MoviePositionId = 1,MovieTypeId = 4, DateTime = new DateTime(2018,02,13,17,30,00) },
                new MoviePositionDates {  Id = 5, MoviePositionId = 2,MovieTypeId = 1, DateTime = new DateTime(2018,02,13,22,30,00) },
                new MoviePositionDates {  Id = 6, MoviePositionId = 2,MovieTypeId = 2, DateTime = new DateTime(2018,02,13,10,30,00) },
                new MoviePositionDates {  Id = 7, MoviePositionId = 3,MovieTypeId = 6, DateTime = new DateTime(2018,02,13,13,30,00) },
                new MoviePositionDates {  Id = 8, MoviePositionId = 3,MovieTypeId = 7, DateTime = new DateTime(2018,02,13,14,30,00) },
            };
            positions.ForEach(d => context.MoviePositionsDates.AddOrUpdate(a => a.Id,d));
            context.SaveChanges();
        }
        private void SeedBanners(CinemaDbContext context)
        {
            CinemaDbContext db = new CinemaDbContext();

            var positions = new List<Banner>{
                new Banner {Id=1, Name="King Arthur", ImagePath="~/Content/images/king.jpg", ImageName="king.jpg"},
                new Banner {Id=2, Name="X-Men", ImagePath="~/Content/images/xmen.jpg",ImageName="xmen.jpg"},
                new Banner {Id=3, Name="Skyfall", ImagePath="~/Content/images/skyfall.jpg",ImageName="skyfall.jpg"}

            };
            positions.ForEach(d => context.Banners.AddOrUpdate(a => a.Name, d));
            context.SaveChanges();
        }
        private void SeedEvents(CinemaDbContext context)
        {
            CinemaDbContext db = new CinemaDbContext();

            var positions = new List<Event>{
                new Event {Id=1, Title="Mecz Polska - Niemcy 12.03.2018",Text="Fdasfdasdf asdfasdfas dsafasdf fdasfdasdf asdfasdfas dsafasdf fdasfdasdf asdfasdfas dsafasdf fdasfdasdf asdfasdfas dsafasdf fdasfdasdf asdfasdfas dsafasdf vfdasfdasdf asdfasdfas dsafasdf fdasfdasdf asdfasdfas dsafasdf", ImagePath="~/Content/images/MECZ.jpg", ImageName="MECZ.jpg"},
                new Event {Id=2, Title="Mecz Polska - Meksyk 17.03.2018",Text="Fdasfdasdf asdfasdfas dsafasdf fdasfdasdf asdfasdfas dsafasdf fdasfdasdf asdfasdfas dsafasdf fdasfdasdf asdfasdfas dsafasdf fdasfdasdf asdfasdfas dsafasdf vfdasfdasdf asdfasdfas dsafasdf fdasfdasdf asdfasdfas dsafasdf", ImagePath="~/Content/images/MECZ.jpg",ImageName="MECZ.jpg"},

            };
            positions.ForEach(d => context.Events.AddOrUpdate(a => a.Title, d));
            context.SaveChanges();
        }
        private void SeedNews(CinemaDbContext context)
        {
            CinemaDbContext db = new CinemaDbContext();

            var positions = new List<News>{
                new News {Id=1, Title="1+1",Text="Piwo 1+1 fasdfas dsafasdf fdasfdasdf asdfasdfas dsafasdf fdasfdasdf asdfasdfas dsafasdf fdasfdasdf asdfasdfas dsafasdf vfdasfdasdf asdfasdfas dsafasdf fdasfdasdf asdfasdfas dsafasdf", ImagePath="~/Content/images/drugiepiwo.jpg", ImageName="drugiepiwo.jpg"}
            };
            positions.ForEach(d => context.News.AddOrUpdate(a => a.Title, d));
            context.SaveChanges();
        }
    }
}
