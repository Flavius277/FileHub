using FileHub.Database.Classes;
using FileHub.Database.Context;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FileHub.Controllers.UsersController
{
    public class UsersService
    {
        private readonly FileHubDb _dbContext;
        public UsersService(FileHubDb dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Users> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public Users? GetUser(string name)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Name == name);

            if (user is null) return null;

            return user;
        }

        public void NewUser([Required] string name)
        {
            var newUser = new Users { Name = name };
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }
    }
}
