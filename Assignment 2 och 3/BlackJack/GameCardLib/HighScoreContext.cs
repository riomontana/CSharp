using System.Data.Entity;

namespace GameCardLib
{
    public class HighScoreContext : DbContext 
    {
        public DbSet<Score> Scores { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
