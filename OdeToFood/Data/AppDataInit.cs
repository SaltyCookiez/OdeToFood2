using Microsoft.AspNetCore.Identity;
using OdeToFood.Models;

namespace OdeToFood.Data
{
    public class AppDataInit
    {
        public static void SeedIdentity(UserManager<UserProfile> userManager, RoleManager<AppRole> roleManager)
        {
            var role = new AppRole();
            role.Name = "Admin";
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                var result = roleManager.CreateAsync(role).Result;
                if (!result.Succeeded)
                {
                    foreach (var idenityError in result.Errors)
                    {
                        Console.WriteLine($"Can not create role! Error: {idenityError.Description}");
                    }
                }
            }
        }
        public static void SeedRestaurant(ApplicationDbContext context)
        {
            if (!context.Restaurants.Any())
            {
                for (int i = 1; i < 1000; i++)
                {
                    context.Restaurants.Add(
                      new Restaurant
                      {
                          Name = $"Cinnamon Club{i}",
                          City = "London",
                          Country = "UK",
                          Reviews = new List<RestaurantReview> {
                             new RestaurantReview() {
                                Rating = 10,
                                Body = "Superlahe!",
                                ReviewerName = $"Jaanus{i}"
                             }
                          }
                      });
                    context.Restaurants.Add(
                      new Restaurant
                      {
                          Name = $"{i} Marrakesh",
                          City = "D.C",
                          Country = "USA",
                      });
                    context.Restaurants.Add(
                      new Restaurant
                      {
                          Name = $"The House of {i}. Elliot",
                          City = "Ghent",
                          Country = "Belgium",
                      });
                }
                context.SaveChanges();
            }
        }
    }
}