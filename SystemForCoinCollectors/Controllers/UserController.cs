﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update;
using SystemForCoinCollectors.Data;

namespace SystemForCoinCollectors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        [HttpPost]
        public JsonResult Create(ApplicationUser user)
        {
            ApplicationUser? userInDb = _context.Users.Find(user.Id);

            if (userInDb == null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }

            return new JsonResult(user) { StatusCode = 200 };
        }

        [HttpPost]
        public JsonResult Edit(ApplicationUser user)
        {
            ApplicationUser? userInDb = _context.Users.Find(user.Id);

            if (userInDb == null)
            {
                return new JsonResult(null) { StatusCode = 404 };
            }

            userInDb.Name = user.Name;
            userInDb.Email = user.Email;
            userInDb.Surname = user.Surname;
            userInDb.Address = user.Address;
            userInDb.UserName = user.UserName;

            _context.SaveChanges();

            return new JsonResult(user) { StatusCode = 200 };
        }

        [HttpGet]
        public JsonResult GetByUserName(string username)
        {
            ApplicationUser userInDb = _context.Users.Where(u => u.UserName == username).FirstOrDefault();
            //ApplicationUser? userInDb = _context.Users.Find(id);
            if (userInDb == null)
            {
                return new JsonResult(null) { StatusCode = 404 };
            }

            return new JsonResult(userInDb) { StatusCode = 200 };
        }

        [HttpGet]
        public JsonResult GetById(string id)
        {
            ApplicationUser? userInDb = _context.Users.Find(id);
            if (userInDb == null)
            {
                return new JsonResult(null) { StatusCode = 404 };
            }

            return new JsonResult(userInDb) { StatusCode = 200 };
        }

        [HttpDelete]
        public JsonResult Delete(string id)
        {
            ApplicationUser? userInDb = _context.Users.Find(id);
            if (userInDb == null)
            {
                return new JsonResult(null) { StatusCode = 404 };
            }

            _context.Remove(userInDb);
            _context.SaveChanges();

            return new JsonResult(null) { StatusCode = 200 };
        }
    }
}
