using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace ForeverGaming.Models
{
    public class GameContext : IdentityDbContext<User>
    {
        public GameContext(DbContextOptions<GameContext> options)
            : base(options)
        { }

        public DbSet<Type> Types { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Game: remove cascading delete with Genre
            modelBuilder.Entity<Game>().HasOne(g => g.Genre)
                .WithMany(g => g.Games)
                .OnDelete(DeleteBehavior.Restrict);

            // Game: remove cascading delete with Format
            modelBuilder.Entity<Game>().HasOne(g => g.Format)
                .WithMany(f => f.Games)
                .OnDelete(DeleteBehavior.Restrict);

            // Game: remove cascading delete with Type
            modelBuilder.Entity<Game>().HasOne(g => g.Type)
                .WithMany(t => t.Games)
                .OnDelete(DeleteBehavior.Restrict);

            // Game: remove cascading delete with Rating
            modelBuilder.Entity<Game>().HasOne(g => g.Rating)
                .WithMany(t => t.Games)
                .OnDelete(DeleteBehavior.Restrict);

            // Game: remove cascading delete with Publisher
            modelBuilder.Entity<Game>().HasOne(g => g.Publisher)
                .WithMany(t => t.Games)
                .OnDelete(DeleteBehavior.Restrict);

            // seed initial data
            modelBuilder.ApplyConfiguration(new SeedFormats());
            modelBuilder.ApplyConfiguration(new SeedGenres());
            modelBuilder.ApplyConfiguration(new SeedGames());
            modelBuilder.ApplyConfiguration(new SeedTypes());
            modelBuilder.ApplyConfiguration(new SeedRatings());
            modelBuilder.ApplyConfiguration(new SeedPublishers());
        }

        public static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            UserManager<User> userManager =
                serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string username = "admin";
            string password = "Sesame";
            string roleName = "Admin";

            // if role doesn't exist, create it
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            // if username doesn't exist, create it and add to role
            if (await userManager.FindByNameAsync(username) == null)
            {
                User user = new User { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }

    }
}
