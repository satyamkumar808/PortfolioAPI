using DAL.DB_Models;
using Shared.Models;

namespace BLL.Service_Interface
{
    public interface IUserService
    {
        Task<User> GetUserByEmail(string email);

        Task<UserModel> Login(UserLoginModel user);
    }
}
