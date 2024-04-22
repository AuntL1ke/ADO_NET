using System.Data.Entity;
using System.Linq;

namespace Home_migrations
{
    public class MusicDB : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Playlist> Playlists { get; set; }

        public MusicDB() : base("name=MusicDb")
        {

        }
    }
}
