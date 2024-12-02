using dotnet_webapi_ef.DataContexts;
using dotnet_webapi_ef.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_webapi_ef.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideoGameController : ControllerBase
{
    private readonly VideoGameDbContext _context;

    public VideoGameController(VideoGameDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VideoGame>>> GetVideoGames()
    {
          var games = await _context.VideoGames.ToListAsync();
          return Ok(games);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<VideoGame>>> GetVideoGame(int id)
    {
         var game = await _context.VideoGames.FindAsync(id);
         if (game == null)
         {
             return NotFound();
         }
         
         return Ok(game);
    }

    [HttpPost]
    public async Task<ActionResult<VideoGame>> AddVideoGame(VideoGame? videoGame)
    {
        if (videoGame == null)
        {
            return BadRequest();
        }

        await _context.VideoGames.AddAsync(videoGame);
        _context.VideoGames.Add(videoGame);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetVideoGame), new { id = videoGame.Id }, videoGame);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVideoGame(int id, VideoGame videoGame)
    {
        var game = await _context.VideoGames.FindAsync(id);
        if (game == null)
        {
            return NotFound();
        }
        
        game.Title = videoGame.Title;
        game.Platform = videoGame.Platform;
        game.Developer = videoGame.Developer;
        game.Publisher = videoGame.Publisher;
        
        await _context.SaveChangesAsync();
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<VideoGame>> DeleteVideoGame(int id)
    {
        var game = await _context.VideoGames.FindAsync(id);
        if (game == null)
        {
            return NotFound();
        }
        
        _context.VideoGames.Remove(game);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}