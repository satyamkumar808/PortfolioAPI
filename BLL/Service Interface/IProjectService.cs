using Shared.Models;

namespace BLL.Service_Interface
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectModel>> GetAllProjects();
        Task<ProjectModel> AddProject(ProjectModel projectModel);
    }
}
