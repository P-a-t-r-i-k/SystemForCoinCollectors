using Microsoft.EntityFrameworkCore;
using SystemForCoinCollectors.Data;

namespace SystemForCoinCollectors.Services
{
    public class AlbumCoinService : IAlbumCoinService
    {
        private readonly ApplicationDbContext _context;

        public AlbumCoinService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Coin>> GetCoinIdsInAlbum(int albumId)
        {
            CoinAlbum? coinAlbum = _context.CoinAlbums.Where(item => item.Id == albumId).Include(item => item.CollectedCoins).FirstOrDefault();
            if (coinAlbum != null)
            {
                return coinAlbum.CollectedCoins.ToList();
            }

            return null;
        }

        public bool AddCoinToAlbum(int albumId, int coinId)
        {
            Coin? coin = _context.Coins.Where(item => item.Id == coinId).FirstOrDefault();
            CoinAlbum? coinAlbum = _context.CoinAlbums.Where(item => item.Id == albumId).Include(item => item.CollectedCoins).FirstOrDefault();
            if (coinAlbum != null && coin != null)
            {
                coinAlbum.CollectedCoins.Add(coin);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool RemoveCoinFromAlbum(int albumId, int coinId)
        {
            Coin? coin = _context.Coins.Where(item => item.Id == coinId).FirstOrDefault();
            CoinAlbum? coinAlbum = _context.CoinAlbums.Where(item => item.Id == albumId).Include(item => item.CollectedCoins).FirstOrDefault();
            if (coinAlbum != null && coin != null)
            {
                coinAlbum.CollectedCoins.Remove(coin);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
