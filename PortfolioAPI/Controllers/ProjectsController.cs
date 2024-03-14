using BLL.Service_Interface;
using Microsoft.AspNetCore.Authorization;
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
            _logger.Log(LogLevel.Information, "Get All projects called");
            IEnumerable<ProjectModel> projects = await _projectService.GetAllProjects();

            return Ok(projects);
        }

        [Authorize]
        [HttpPost]
        [Route("AddProject")]
        public async Task<ActionResult<ProjectModel>> AddProject([FromBody] ProjectModel model)
        {
            _logger.Log(LogLevel.Information, "Add project called");
            ProjectModel project = await _projectService.AddProject(model);

            if(project == null)
            {
                return BadRequest(project);
            }

            return Ok(project);
        }
    }
}
