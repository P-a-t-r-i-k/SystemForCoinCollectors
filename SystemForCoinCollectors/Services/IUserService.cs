using SystemForCoinCollectors.Data;

namespace SystemForCoinCollectors.Services
{
    public interface IUserService
    {
        public Task<List<ApplicationUser>> GetAllUsers();

        public Task DeleteUser(string username);
        public Task<ApplicationUser?> GetUser(string username);
        public Task<ApplicationUser?> GetUserByEmail(string email);
        public Task LogOut();
        public Task Edit(ApplicationUser user, string oldUsername);
    }
}
