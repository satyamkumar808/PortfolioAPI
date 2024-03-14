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

        public async Task<ProjectModel> AddProject(ProjectModel projectModel)
        {
            ProjectModel addedProjectModel;
            try
            {
                Project project = new Project { Description = projectModel.Description, Name = projectModel.Name, GitLink = projectModel.GitLink };
                Project addedProject = await _projectRepository.AddProject(project);
                if(addedProject != null)
                {
                    addedProjectModel = new ProjectModel { Description = addedProject.Description, Name = addedProject.Name, GitLink = addedProject.GitLink, ProjectId = addedProject.Id };
                }
                else
                {
                    addedProjectModel = new ProjectModel();
                }
                return addedProjectModel;
            }
            catch (Exception ex)
            {
                throw;
            }
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
