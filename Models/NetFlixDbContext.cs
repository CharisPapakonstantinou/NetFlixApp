using System.Data.Entity;

namespace NetflixApp.Models
{
    public class NetFlixDbContext : DbContext
    {
        public DbSet<Serie> Series { get; set; }
    }
}