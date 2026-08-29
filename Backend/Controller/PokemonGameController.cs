using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeDex.Data;
using PokeDex.Data.Models;

namespace PokeDex.Backend.Controller
{
    [ApiController]
    [Route("api/pokemon-game")]
    public class PokemonGameController(ApplicationDbContext db) : ControllerBase
    {
        private readonly ApplicationDbContext _db = db;

    [HttpGet]
        public async Task<IActionResult> GetGame()
        {
            var games = await _db.PokemonGame
                .AsNoTracking()
                .Select(game => new
                {
                    game.Id,
                    game.Name,
                    game.Slug
                })
                .ToListAsync();

            return Ok(games);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGameById(int id)
        {
            var game = await _db.PokemonGame
                .AsNoTracking()
                .Where(game => game.Id == id)
                .Select(game => new
                {
                    game.Id,
                    game.GenerationId,
                    game.Name,
                    game.Slug
                })
                .FirstOrDefaultAsync();

            if (game is null)
                return NotFound();

            return Ok(game);
        }
    }
}
