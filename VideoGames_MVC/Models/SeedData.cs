using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VideoGames_MVC.Data;
using System;
using System.Linq;

namespace VideoGames_MVC.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new VideoGames_MVCContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<VideoGames_MVCContext>>()))
            {
                // Look for any movies.
                if (context.VideoGames.Any())
                {
                    return;   // DB has been seeded
                }

                context.VideoGames.AddRange(
                    new VideoGames
                    {
                        Name = "Cities Skyline",
                        AgeRating = 8,
                        ReleaseDate = DateTime.Parse("2007-2-10"),
                        MultiPlayer = false,
                        Genre = "City Building",
                        Price = 19.99M
                    },

                    new VideoGames
                    {
                        Name = "Valorant ",
                        AgeRating = 13,
                        ReleaseDate = DateTime.Parse("2015-3-30"),
                        MultiPlayer = true,
                        Genre = "Shooter",
                        Price = 4.99M
                    },

                    new VideoGames
                    {
                        Name = "Shadow Empires",
                        AgeRating = 3,
                        ReleaseDate = DateTime.Parse("2014-8-13"),
                        MultiPlayer = true,
                        Genre = "Stradegy",
                        Price = 14.99M
                    },

                    new VideoGames
                    {
                        Name = "BattleField",
                        AgeRating = 17,
                        ReleaseDate = DateTime.Parse("2006-4-15"),
                        MultiPlayer = true,
                        Genre = "Shooter",
                        Price = 59.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}