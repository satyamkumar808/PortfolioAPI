using BLL.Service_Interface;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace PortfolioAPI.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ILogger<ProjectsController> _logger;
        private readonly IProjectService _projectService;
        public ProjectsController(ILogger<ProjectsController> logger, IProjectService projectService)
        {

            _logger = logger;
            _projectService = projectService;

        }

        [HttpGet]
        [Route("GetAllProjects")]
        public async Task<ActionResult<IEnumerable<ProjectModel>>> GetAllProjects()
        {
            string a = "";
            _logger.Log(LogLevel.Information, "Get All projects called");
            IEnumerable<ProjectModel> projects = await _projectService.GetAllProjects();

            return Ok(projects);
        }
    }
}
