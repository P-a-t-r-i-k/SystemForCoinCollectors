using SystemForCoinCollectors.Data;

namespace SystemForCoinCollectors.Services
{
    public interface IAlbumService
    {
        public List<CoinAlbum> GetAllUserAlbums(string ownerId);
        public Task<int> GetCollectionAlbumTypeId();
        public Task<int> GetDuplicateAlbumTypeId();
        public Task<int> GetWishlistAlbumTypeId();
        public Task CreateAlbumsForNewUser(ApplicationUser user);
        public Task DeleteUserAlbums(ApplicationUser user);
    }
}
