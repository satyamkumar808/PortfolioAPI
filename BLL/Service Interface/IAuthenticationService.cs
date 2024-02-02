using DAL.DB_Models;
using Shared.Models;

namespace BLL.Service_Interface
{
    public interface IAuthenticationService
    {
        public Task<UserModel> GenerateTocken(User user);
    }
}
