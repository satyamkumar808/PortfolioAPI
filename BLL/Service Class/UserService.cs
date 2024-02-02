using BLL.Service_Interface;
using DAL.DB_Models;
using DAL.RepositoryInterface;
using Shared.Models;

namespace BLL.Service_Class
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;

        public UserService(IUserRepository userRepository, IAuthenticationService authenticationService)
        {
            _userRepository = userRepository;
            _authenticationService = authenticationService;

        }
        public async Task<User> GetUserByEmail(string email)
        {
            User searchedUser;
            try
            {
                searchedUser =  await this._userRepository.GetUserByEmail(email);
            }
            catch(Exception ex)
            {
                throw;
            }
            return searchedUser;
        }

        public async Task<UserModel> Login(UserLoginModel user)
        {
            UserModel authUser = null;
            try
            {
                User userExist = await this._userRepository.GetUserByEmail(user.UserEmail);
                if(userExist != null && user.UserPassword == userExist.Password) 
                {
                    authUser = await this._authenticationService.GenerateTocken(userExist);
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return authUser;
        }
    }
}
