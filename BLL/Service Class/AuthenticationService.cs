using BLL.Service_Interface;
using DAL.DB_Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BLL.Service_Class
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public async Task<UserModel> GenerateTocken(User user)
        {
            UserModel authUser = null;
            try
            {

                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

                SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = this._configuration.GetValue<string>("Auth:Issuer"),
                    Audience = this._configuration.GetValue<string>("Auth:Audi"),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this._configuration.GetValue<string>("Auth:Key"))), SecurityAlgorithms.HmacSha256Signature),
                    Claims = new Dictionary<string, object>
                    {
                        { "Name", user.UserName },
                        { ClaimTypes.Role, "Admin" },
                    },
                    Expires = DateTime.UtcNow.AddMinutes(10)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                authUser = new UserModel
                {
                    Id = user.Id,
                    UserEmail = user.UserEmail,
                    UserName = user.UserName,
                    Tocken = tokenHandler.WriteToken(token)
                };


            }
            catch(Exception ex)
            {
                throw;
            }
            return authUser;
        }
    }
}
