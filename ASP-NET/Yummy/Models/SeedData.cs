using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Yummy.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new YummyContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<YummyContext>>()))
            {
                // Look for any recipes.
                if (context.Recipes.Any())
                {
                    return;   // DB has been seeded
                }

                context.Recipes.AddRange(
                    new Recipes
                    {
                        Name = "Hamburger",
                        Time = DateTime.Parse("2021-2-12"),
                        Difficulty = "Easy",
                        Likes = 512,
                        Ingredients = "meat, salad, bread, tomatos, mustard",
                        Process = "Go to Macdo",
                        Tips_and_Trick = "no"
                    },

                    new Recipes
                    {
                        Name = "Chocolate cake",
                        Time = DateTime.Parse("2022-6-10"),
                        Difficulty = "Hard",
                        Likes = 2,
                        Ingredients = "Chocolate, eggs, sugar...",
                        Process = "Buy on internet",
                        Tips_and_Trick = "Have some money"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}