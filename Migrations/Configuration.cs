namespace NetflixApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using NetflixApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<NetflixApp.Models.NetFlixDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NetflixApp.Models.NetFlixDbContext context)
        {
            context.Series.AddOrUpdate(s => s.Title,
                new Serie
                {
                    Title = "Breaking Bad",
                    Genre = "Drama",
                    ReleaseDate = DateTime.Parse("2004-3-4"),
                    Seasons = 6
                },

                new Serie
                {
                    Title = "Lost",
                    Genre = "Mystery",
                    ReleaseDate = DateTime.Parse("2005-6-4"),
                    Seasons = 6
                },

                new Serie
                {
                    Title = "Peaky Blinders",
                    Genre = "Drama",
                    ReleaseDate = DateTime.Parse("2012-8-4"),
                    Seasons = 4
                },

                new Serie
                {
                    Title = "Dexter",
                    Genre = "Criminal",
                    ReleaseDate = DateTime.Parse("2015-3-9"),
                    Seasons = 8
                }
            );
        }
    }
}
