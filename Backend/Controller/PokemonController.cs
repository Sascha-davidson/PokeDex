using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeDex.Data;

namespace PokeDex.Backend.Controller
{
    [ApiController]
    [Route("api/pokemon")]
    public class PokemonController(ApplicationDbContext db) : ControllerBase
    {
        private readonly ApplicationDbContext _db = db;

        [HttpGet]
        public async Task<IActionResult> GetPokemon()
        {
            var pokemon = await _db.Pokemons
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.NationalDexNumber,
                    p.ImageUrl,
                })
                .ToListAsync();

            return Ok(pokemon);
        }

    }
}
