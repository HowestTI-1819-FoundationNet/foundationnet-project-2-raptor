using Microsoft.EntityFrameworkCore;
using SuperAwesomeRaptorRacingGame_Backend.Entities;

namespace SuperAwesomeRaptorRacingGame_Backend.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Score> Scores { get; set; }
    }
}
