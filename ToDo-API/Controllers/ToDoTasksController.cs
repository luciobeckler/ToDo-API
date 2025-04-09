using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo_API.Dtos;
using ToDo_API.Services.Groups;
using ToDo_API.Services.ToDoTasks;

namespace ToDo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoTasksController : ControllerBase
    {
        private readonly IToDoTasksService _toDoTasksService;
        private readonly IGroupsService _groupsService;

        public ToDoTasksController(IToDoTasksService toDoTasksService, IGroupsService groupsService)
        {
            _toDoTasksService = toDoTasksService;
            _groupsService = groupsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.ToDoTask>>> GetAll()
        {
            var tasks = await _toDoTasksService.GetAllAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.ToDoTask>> GetById(int id)
        {
            var task = await _toDoTasksService.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<Models.ToDoTask>> Create(ToDoTaskDTO todoTaskDTO)
        {
            var todoTask = new Models.ToDoTask()
            {
                Title = todoTaskDTO.Title,
                Description = todoTaskDTO.Description,
                Status = todoTaskDTO.Status,
                Priority = todoTaskDTO.Priority,
                StartDateTime = todoTaskDTO.StartDateTime,
                EndDateTime = todoTaskDTO.EndDateTime,
                GroupId = todoTaskDTO.GroupId
            };

            try
            {
                await _toDoTasksService.AddAsync(todoTask);
                return Ok(todoTask);
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


        [HttpPut]
        public async Task<ActionResult> Update(int id, ToDoTaskDTO todoTaskDTO)
        {
            try
            {
                var existingTask = await _toDoTasksService.GetByIdAsync(id);
                if (existingTask == null)
                    return NotFound("Task not found.");

                existingTask.Title = todoTaskDTO.Title;
                existingTask.Description = todoTaskDTO.Description;
                existingTask.Status = todoTaskDTO.Status;
                existingTask.Priority = todoTaskDTO.Priority;
                existingTask.StartDateTime = todoTaskDTO.StartDateTime;
                existingTask.EndDateTime = todoTaskDTO.EndDateTime;
                existingTask.GroupId = todoTaskDTO.GroupId;

                await _toDoTasksService.UpdateAsync(existingTask);
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


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _toDoTasksService.DeleteAsync(id);
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
