using SystemForCoinCollectors.Data;

namespace SystemForCoinCollectors.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly ApplicationDbContext _context;
        public AlbumService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<CoinAlbum> GetAllUserAlbums(string ownerId)
        {
            var albums = _context.CoinAlbums.Where(item => item.ApplicationUser.Id == ownerId);
            return albums.ToList();
        }

        public async Task<int> GetCollectionAlbumTypeId()
        {
            var album = _context.AlbumTypes.Where(item => item.Type == "Collection").FirstOrDefault();
            if (album != null)
            {
                return album.Id;
            }

            return -1;
        }

        public async Task<int> GetDuplicateAlbumTypeId()
        {
            var album = _context.AlbumTypes.Where(item => item.Type == "Duplicate").FirstOrDefault();
            if (album != null)
            {
                return album.Id;
            }

            return -1;
        }

        public async Task<int> GetWishlistAlbumTypeId()
        {
            var album = _context.AlbumTypes.Where(item => item.Type == "Wishlist").FirstOrDefault();
            if (album != null)
            {
                return album.Id;
            }

            return -1;
        }
    }
}
