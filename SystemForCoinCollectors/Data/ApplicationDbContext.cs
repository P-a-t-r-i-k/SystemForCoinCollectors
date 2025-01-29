using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SystemForCoinCollectors.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Coin> Coins { get; set; }
        public DbSet<AlbumType> AlbumTypes { get; set; }
        public DbSet<CoinAlbum> CoinAlbums { get; set; }
     
    }
}
