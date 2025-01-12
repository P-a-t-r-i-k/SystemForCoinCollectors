using SystemForCoinCollectors.Data;

namespace SystemForCoinCollectors.Services
{
    public interface ICoinService
    {
        Task<List<Coin>> GetAllCoins();
        Task<Coin> AddCoin(Coin coin);
    }
}
