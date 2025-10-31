using CollegeAPI.Models;
namespace CollegeAPI.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}