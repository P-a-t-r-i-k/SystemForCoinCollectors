using SystemForCoinCollectors.Data;

namespace SystemForCoinCollectors.Services
{
    public interface IUserService
    {
        public Task<List<ApplicationUser>> GetAllUsers();
    }
}
