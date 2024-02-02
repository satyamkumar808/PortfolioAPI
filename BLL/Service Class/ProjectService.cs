using BLL.Service_Interface;
using DAL;
using DAL.RepositoryInterface;
using Shared.Models;

namespace BLL.Service_Class
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;   
        }
        public async Task<IEnumerable<ProjectModel>> GetAllProjects()
        {
            try
            {
                IEnumerable<Project> projects = await _projectRepository.GetAll();
                IEnumerable<ProjectModel> result = new List<ProjectModel>();
                foreach (Project project in projects)
                {
                    ProjectModel projectModel = new ProjectModel { ProjectId = project.Id, Description = project.Description, Name = project.Name };
                    result = result.Append(projectModel);
                }
                return result.ToArray();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
