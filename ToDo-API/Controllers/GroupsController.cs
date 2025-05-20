using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
        public async Task<ActionResult<IEnumerable<Models.Group>>> GetAllAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if(userId == null)
                return Unauthorized("Usuário não autenticado.");

            var groups = await _groupsService.GetAllAsync(userId);

            return Ok(groups);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Group>> GetById(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrWhiteSpace(userId))
                return Unauthorized("Usuário não autenticado.");

            var group = await _groupsService.GetById(id, userId);

            if (group == null)
                return NotFound("Grupo não encontrado.");

            return Ok(group);
        }

        [HttpPost]
        public async Task<ActionResult<Models.Group>> Create(GroupDTO groupDTO)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
                return Unauthorized("Usuário não autenticado.");

            try
            {
                var group = new Models.Group()
                {
                    Title = groupDTO.Title,
                    UserId = userId
                };

                await _groupsService.AddAsync(group);
                return Created();
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult> Update(int id, GroupDTO groupDTO)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
                return Unauthorized("Usuário não autenticado.");

            try
            {
                var group = await _groupsService.GetById(id, userId);

                group.Title = groupDTO.Title;

                await _groupsService.UpdateAsync(group);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
                return Unauthorized("Usuário não autenticado.");

            try
            {
                await _groupsService.DeleteByIdAsync(id, userId);
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
