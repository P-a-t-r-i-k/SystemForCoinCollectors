using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemForCoinCollectors.Components.Account.Pages.Manage;
using SystemForCoinCollectors.Controllers;
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
            return _context.Users.Where(u => u.UserName == username).FirstOrDefault();
        }

        public async Task<ApplicationUser?> GetUserByEmail(string email)
        {
            return _context.Users.Where(u => u.Email == email).FirstOrDefault();
        }

        public async Task<ApplicationUser?> GetUserById(string userId)
        {
            return _context.Users.Where(u => u.Id == userId).FirstOrDefault();
        }

        public async Task ChangeEmail(string userId, string newEmail)
        {
            var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
            if (user != null)
            {
                user.Email = newEmail;
                user.NormalizedEmail = newEmail.ToUpper();
            }
        }

        public async Task ChangeReputationPoints(string userId, int newReputationPoints)
        {
            var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
            if (user != null)
            {
                user.ReputationPoints = newReputationPoints;
            }
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task Edit(ApplicationUser user, string oldUsername)
        {
            ApplicationUser? userInDb = _context.Users.Where(u => u.UserName == oldUsername).FirstOrDefault(); ;

            if (userInDb != null)
            {
                userInDb.Name = user.Name;
                userInDb.Email = user.Email;
                userInDb.Surname = user.Surname;
                userInDb.Address = user.Address;
                userInDb.UserName = user.UserName;

                await _context.SaveChangesAsync();
            }
        }

        public string GetUsername(string id)
        {
            ApplicationUser? user = _context.Users.FirstOrDefault(item => item.Id == id);
            
            if (user == null || user.UserName == null)
            {
                return "";
            }
            return user.UserName;
        }
    }
}
