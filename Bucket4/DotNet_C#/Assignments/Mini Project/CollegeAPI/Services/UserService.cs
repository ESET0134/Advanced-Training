using CollegeAPI.Models;
using CollegeAPI.Services;

namespace CollegeAPI.Services
{
    public class UserService : IUserService
    {
        private readonly CollegeDbContext _context;

        public UserService(CollegeDbContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
