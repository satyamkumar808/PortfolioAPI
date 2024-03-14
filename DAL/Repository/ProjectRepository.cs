using DAL.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Project> AddProject(Project project)
        {
            try
            {
                var context = _dbContext.Project.Add(project);
                _dbContext.SaveChanges();
                return context.Entity;
            }
            catch (Exception ex)
            {
                throw;
            }
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
