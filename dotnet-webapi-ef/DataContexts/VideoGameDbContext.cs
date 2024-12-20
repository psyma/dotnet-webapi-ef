using dotnet_webapi_ef.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_webapi_ef.DataContexts;

public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
{
    public DbSet<VideoGame> VideoGames => Set<VideoGame>();
    
    // Override this function for seeding data
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("videogame");
        
        modelBuilder.Entity<VideoGame>().HasData(
            new VideoGame
            {
                Id = 1,
                Title = "Spiderman-Man 2",
                Platform = "PS5", 
            },
            new VideoGame
            {
                Id = 2,
                Title = "The Legend of Zelda: Breath of the Wild",
                Platform = "Nintendo Switch", 
            },
            new VideoGame
            {
                Id = 3,
                Title = "Cyberpunk 2077",
                Platform = "PC", 
            });
    }
}