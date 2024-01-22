using DAL.DAO;
using DAOInterfaces.DTO;
using DAOInterfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ProjectPage.Models;

namespace AccountPage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShowcaseController : ControllerBase
    {
        private readonly IProjectDAO _projectDAL;

        public ShowcaseController(IProjectDAO projectDAL)
        {
            _projectDAL = projectDAL;
        }

        [HttpGet("{projectId}")]
        public async Task<ActionResult<List<ShowcaseItemViewModel>>> GetShowcaseItems(string projectId)
        {
            List<ShowcaseItemDTO> showcaseItems = await _projectDAL.GetShowcaseItems(projectId);
            return Ok(showcaseItems.Select(showcaseItem => new ShowcaseItemViewModel
            {
                Id = showcaseItem.Id,
                ProjectId = showcaseItem.ProjectId,
                UserId = showcaseItem.UserId,
                type = showcaseItem.type,
                Description = showcaseItem.Description,
                Img = showcaseItem.Img
            }).ToList());
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<ShowcaseItemViewModel>>> GetShowcaseItemsByUser(string userId)
        {
            List<ShowcaseItemDTO> showcaseItems = await _projectDAL.GetShowcaseItemsByUser(userId);
            return Ok(showcaseItems.Select(showcaseItem => new ShowcaseItemViewModel
            {
                Id = showcaseItem.Id,
                ProjectId = showcaseItem.ProjectId,
                UserId = showcaseItem.UserId,
                type = showcaseItem.type,
                Description = showcaseItem.Description,
                Img = showcaseItem.Img
            }).ToList());
        }

        [HttpPost]
        public async Task<ActionResult<ShowcaseItemViewModel>> CreateShowcaseItem(ShowcaseItemViewModel showcaseItem)
        {
            ShowcaseItemDTO showcaseItemDTO = new ShowcaseItemDTO
            {
                ProjectId = showcaseItem.ProjectId,
                UserId = showcaseItem.UserId,
                type = showcaseItem.type,
                Description = showcaseItem.Description,
                Img = showcaseItem.Img
            };
            await _projectDAL.CreateShowcaseItem(showcaseItemDTO);
            return CreatedAtAction(nameof(GetShowcaseItems), new { projectId = showcaseItem.ProjectId }, showcaseItem);
        }
    }
}
