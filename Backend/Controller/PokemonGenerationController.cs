using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeDex.Data;
using PokeDex.Data.Models;

namespace PokeDex.Backend.Controller
{
    [ApiController]
    [Route("api/pokemon-generation")]
    public class PokemonGenerationController(ApplicationDbContext db) : ControllerBase
    {
        private readonly ApplicationDbContext _db = db;

    // GET: api/pokemon-generation
    [HttpGet]
        public async Task<IActionResult> GetGeneration()
        {
            var generations = await _db.PokemonGeneration
                .AsNoTracking()
                .Select(generation => new
                {
                    generation.Id,
                    generation.Name,
                    generation.Slug
                })
                .ToListAsync();

            return Ok(generations);
        }

        // GET: api/pokemon-generation/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGenerationById(int id)
        {
            var generation = await _db.PokemonGeneration
                .AsNoTracking()
                .Where(generation => generation.Id == id)
                .Select(generation => new
                {
                    generation.Id,
                    generation.Name,
                    generation.Slug
                })
                .FirstOrDefaultAsync();

            if (generation is null)
                return NotFound();

            return Ok(generation);
        }
    }
}
