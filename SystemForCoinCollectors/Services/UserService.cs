using Microsoft.EntityFrameworkCore;
using SystemForCoinCollectors.Data;

namespace SystemForCoinCollectors.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task DeleteUser(string username)
        {
            ApplicationUser userToDelete = _context.Users.Where(u => u.UserName == username).FirstOrDefault();
            _context.Remove(userToDelete);
            _context.SaveChanges();
            Console.WriteLine("User deleted from database.");
        }
    }
}
