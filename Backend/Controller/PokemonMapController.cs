using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeDex.Data;

namespace PokeDex.Backend.Controller
{
    [ApiController]
    [Route("api/pokemon-map")]
    public class PokemonMapController(ApplicationDbContext db) : ControllerBase
    {
        private readonly ApplicationDbContext _db = db;

        [HttpGet]
        public async Task<IActionResult> GetMap()
        {
            var maps = await _db.PokemonMaps
            .AsNoTracking()
            //.Where(map =>
            //    _db.PokemonRegions.Any(region =>
            //        region.Id == map.RegionId &&
            //        region.GenerationId == generationId))
            .Select(map => new
            {
                map.Id,
                map.RegionId,
                map.Name,
                map.Slug,
                map.SvgPath
            })
            .ToListAsync();

            return Ok(maps);
        }

        [HttpGet("{generationId:int}/{gameId:int}")]
        public async Task<IActionResult> GetMapByGenerationAndGame(
        int generationId,
        
        int gameId)
        {
            var maps = await _db.PokemonMaps
            .AsNoTracking()
            .Where(map =>
                map.GameId == gameId &&
                _db.PokemonRegions.Any(region =>
                region.Id == map.RegionId &&
                region.GenerationId == generationId))
            .Select(map => new
            {
                map.Id,
                map.RegionId,
                map.Name,
                map.Slug,
                map.SvgPath
            })
            .ToListAsync();

            return Ok(maps);

        }
    }
}
