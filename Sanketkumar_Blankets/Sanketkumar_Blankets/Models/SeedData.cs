using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sanketkumar_Blankets.Data;
using System;
using System.Linq;

namespace Sanketkumar_Blankets.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Blankets.Any())
                {
                    return;   // DB has been seeded
                }

                context.Blankets.AddRange(
                    new Blankets
                    {
                        Title = "Apparive ",
                        Price = 7,
                        Material = "Silk",
                        Rating = 4

                    },

                    new Blankets
                    {
                        Title = "Purple cab ",
                        Price = 8,
                        Material = "Silk",
                        Rating = 4

                    },

                    new Blankets
                    {
                        Title = "Satva ",
                        Price = 10,
                        Material = "Silk",
                        Rating = 1
                    },

                    new Blankets
                    {
                        Title = "Cozy",
                        Price = 11,
                        Material = "Soft",
                        Rating = 2
                    },
                    new Blankets
                    {
                        Title = "LL Bean",
                        Price = 6,
                        Material = "hard",
                        Rating = 3
                    },
                    new Blankets
                    {
                        Title = "Poetry bean",
                        Price = 21,
                        Material = "Soft",
                        Rating = 5
                    },
                    new Blankets
                    {
                        Title = "Un hide",
                        Price = 11,
                        Material = "Soft",
                        Rating = 5
                    },
                    new Blankets
                    {
                        Title = "Blaek Hv",
                        Price = 19,
                        Material = "Soft",
                        Rating = 4
                    },
                    new Blankets
                    {
                        Title = "Green White",
                        Price = 51,
                        Material = "Soft",
                        Rating = 3
                    },
                    new Blankets
                    {
                        Title = "Yell",
                        Price = 21,
                        Material = "Soft",
                        Rating = 5
                    }

                ); 
                context.SaveChanges();
            }
        }
    }
}
