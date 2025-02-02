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

        public Task<List<Coin>> GetCoinsByYear(string year)
        {
            var coins = _context.Coins.Where(coin => coin.IssuingYear == year).ToListAsync();
            return coins;
        }

        public Task<List<string>> GetYears()
        {
            var years = _context.Coins.Select(coin => coin.IssuingYear).Distinct().ToListAsync();
            return years;
        }

        public Task<List<string>> GetCountries()
        {
            var countries = _context.Coins.Select(coin => coin.Country).Distinct().ToListAsync();
            return countries;
        }

        public async Task<Coin> AddCoin(Coin coin)
        {
            _context.Coins.Add(coin);
            await _context.SaveChangesAsync();

            return coin;
        }

        public async Task UpdateCoin(int id, Coin newCoin)
        {
            Coin? coinInDb = await GetById(id);
            if (coinInDb != null)
            {
                coinInDb.Feature = newCoin.Feature;
                coinInDb.Description = newCoin.Description;
                coinInDb.IssuingVolume = newCoin.IssuingVolume;
                coinInDb.IssuingYear = newCoin.IssuingYear;
                coinInDb.Country = newCoin.Country;
                coinInDb.ImagePath = newCoin.ImagePath;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCoin(int id)
        {
            Coin? coin = await GetById(id);
            if (coin != null)
            {
                _context.Remove(coin);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Coin?> GetById(int id)
        {
            return _context.Coins.Where(coin => coin.Id == id).FirstOrDefault();
        }
    }
}
