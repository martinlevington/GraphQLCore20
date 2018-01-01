using Microsoft.EntityFrameworkCore;
using StarWars.Core.Models;

namespace StarWars.Data.EfCore
{
    public sealed class StarWarsContext : DbContext
    {

        public StarWarsContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Droid> Droids { get; set; }
    }
}
