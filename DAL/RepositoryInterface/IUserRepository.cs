using DAL.DB_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryInterface
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string userEmail);
    }
}
