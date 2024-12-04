using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SystemForCoinCollectors.Data;

namespace SystemForCoinCollectors.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private SignInManager<ApplicationUser> _signInManager;

        public UserService(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
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
            await _context.SaveChangesAsync();
        }

        public async Task<ApplicationUser?> GetUser(string username)
        {
            ApplicationUser? user = _context.Users.Where(u => u.UserName == username).FirstOrDefault();
            return user;
        }


        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
