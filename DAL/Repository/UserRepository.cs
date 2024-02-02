using DAL.DB_Models;
using DAL.RepositoryInterface;
using System;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ProtfolioDBContext _dbContext;
        public UserRepository(ProtfolioDBContext dBContext)
        {

           _dbContext = dBContext;

        }
        public async Task<User> GetUserByEmail(string userEmail)
        {
            User user =null;
            try
            {
                user = this._dbContext.Users.FirstOrDefault(u => u.UserEmail == userEmail);
            }
            catch(Exception ex) 
            {
                throw;
            }
            return user;
        }
    }
}
