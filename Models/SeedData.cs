using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "Tenet",
                    ReleaseDate = DateTime.Parse("2020-9-3"),
                    Genre = " Science Fiction Action Thriller ",
                    Rating = "PG-13",
                    Price = 205M
                },
                new Movie
                {
                    Title = "The Secret Life of Walter Mitty",
                    ReleaseDate = DateTime.Parse("2013-12-25"),
                    Genre = "Adventure Comedy",
                    Rating = "PG",
                    Price = 90M
                },
                new Movie
                {
                    Title = "Rush",
                    ReleaseDate = DateTime.Parse("2013-9-3"),
                    Genre = " Biographical Sports",
                    Rating = "R",
                    Price = 38M
                },
                new Movie
                {
                    Title = "Tropic Thunder",
                    ReleaseDate = DateTime.Parse("2008-8-13"),
                    Genre = "Satirical Action Comedy",
                    Rating = "R",
                    Price = 92M
                }
            );
            context.SaveChanges();
        }
    }
}