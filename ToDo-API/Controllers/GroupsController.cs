using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo_API.Dtos;
using ToDo_API.Services.Groups;

namespace ToDo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupsService _groupsService;

        public GroupsController(IGroupsService groupsService)
        {
            _groupsService = groupsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Group>>> GetAll()
        {
            var groups = await _groupsService.GetAllAsync();
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Group>> GetById(int id)
        {
            var group = await _groupsService.GetByIdAsync(id);
            if (group == null)
            {
                return NotFound("Group not found");
            }
            return Ok(group);
        }

        [HttpPost]
        public async Task<ActionResult<Models.Group>> Create(GroupDTO groupDTO)
        {
            var group = new Models.Group()
            {
                Title = groupDTO.Title,
            };

            await _groupsService.AddAsync(group);
            return Ok(group);
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update(int id, GroupDTO groupDTO)
        {
            try
            {
                var group = new Models.Group()
                {
                    Id = id,
                    Title = groupDTO.Title,
                };
                await _groupsService.UpdateAsync(group);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _groupsService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
