using SystemForCoinCollectors.Data;

namespace SystemForCoinCollectors.Services
{
    public interface ICoinService
    {
        Task<List<Coin>> GetAllCoins();
        Task<List<Coin>> GetCoinsByYear(string year);
        Task<List<string>> GetYears();
        Task<List<string>> GetCountries();
        Task<Coin> AddCoin(Coin coin);
        Task<Coin?> GetById(int id);
    }
}
