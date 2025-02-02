using SystemForCoinCollectors.Data;

namespace SystemForCoinCollectors.Services
{
    public interface IAlbumCoinService
    {
        Task<List<Coin>> GetCoinIdsInAlbum(int albumId);
        bool AddCoinToAlbum(int albumId, int coinId);
        bool RemoveCoinFromAlbum(int albumId, int coinId);
        Task<List<AdminChangesInUserTableHistory>> GetAllRecords();
    }
}
