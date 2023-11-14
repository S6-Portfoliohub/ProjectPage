using AccountPage.Models;
using DAL.DAO;
using DAOInterfaces.DTO;
using DAOInterfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AccountPage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectDAO _projectDAL;

        public ProjectController(IProjectDAO projectDAL)
        {
            _projectDAL = projectDAL;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<ProjectViewModel>> GetAllProjectsFromUser(string projectId)
        {
            ProjectDTO projectDTOs = await _projectDAL.GetProjectById(projectId);
            ProjectViewModel project = new ProjectViewModel() { Id = projectDTOs.Id, Description = projectDTOs.Description, Name = projectDTOs.Name, Img = projectDTOs.Img };

            return project;
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult> CreateProject(ProjectViewModel project)
        {
            await _projectDAL.AddProjectForUser(new() { Name = project.Name, Description = project.Description, UserId = "test" });
            return Ok();
        }
    }
}
