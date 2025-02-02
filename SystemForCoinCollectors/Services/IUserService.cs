using SystemForCoinCollectors.Data;

namespace SystemForCoinCollectors.Services
{
    public interface IUserService
    {
        public Task<List<ApplicationUser>> GetAllUsers();

        public Task DeleteUser(string username);
        public Task<ApplicationUser?> GetUser(string username);
        public Task<ApplicationUser?> GetUserByEmail(string email);
        public Task<ApplicationUser?> GetUserById(string userId);
        public Task ChangeEmail(string userId, string newEmail);
        public Task ChangeReputationPoints(string userId, int newReputationPoints);
        public Task LogOut();
        public Task Edit(ApplicationUser user, string oldUsername);
        public string GetUsername(string id);
    }
}
