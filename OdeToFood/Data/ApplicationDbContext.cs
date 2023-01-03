using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Models;

namespace OdeToFood.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserProfile>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}