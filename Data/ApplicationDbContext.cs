using Microsoft.EntityFrameworkCore;

using Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // This tells EF Core to create a table named "Pokemons" based on your class
    public DbSet<Pokemon> Pokemons { get; set; }
}