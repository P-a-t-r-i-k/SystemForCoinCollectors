using SystemForCoinCollectors.Data;

namespace SystemForCoinCollectors.Services
{
    public interface ICoinService
    {
        Task<List<Coin>> GetAllCoins();
        Task<List<Coin>> GetCoinsByYear(string year);
        Task<List<string>> GetYears();
        Task<List<string>> GetYearsDescending();
        Task<List<string>> GetCountries();
        Task<Coin> AddCoin(Coin coin);
        Task UpdateCoin(int id, Coin newCoin);
        Task DeleteCoin(int id);
        Task<Coin?> GetById(int id);
    }
}
