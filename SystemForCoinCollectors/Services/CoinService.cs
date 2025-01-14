using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using SystemForCoinCollectors.Data;

namespace SystemForCoinCollectors.Services
{
    public class CoinService : ICoinService
    {
        private readonly ApplicationDbContext _context;

        public CoinService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Coin>> GetAllCoins()
        {
            var coins = await _context.Coins.ToListAsync();
            return coins;
        }

        public async Task<Coin> AddCoin(Coin coin)
        {
            _context.Coins.Add(coin);
            await _context.SaveChangesAsync();

            return coin;
        }

        public async Task<Coin?> GetById(int id)
        {
            return _context.Coins.Where(coin => coin.Id == id).FirstOrDefault();
        }
    }
}
