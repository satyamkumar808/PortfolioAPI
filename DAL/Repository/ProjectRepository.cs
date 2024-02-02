using DAL.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProtfolioDBContext _dbContext;
        public ProjectRepository(ProtfolioDBContext dbContext)
        {
            _dbContext = dbContext;   
        }
        public async Task<IEnumerable<Project>> GetAll()
        {
            try
            {
                return _dbContext.Project.ToArray();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
