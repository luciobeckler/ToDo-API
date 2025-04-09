using ToDo_API.Models;
using ToDo_API.Repositorys.Groups;
using ToDo_API.Repositorys.ToDoTasks;

namespace ToDo_API.Services.ToDoTasks
{
    public class ToDoTasksService : IToDoTasksService
    {
        private readonly IToDoTasksRepository _toDoTasksRepository;
        private readonly IGroupsRepository _groupsRepository;

        public ToDoTasksService(IToDoTasksRepository toDoTasksRepository, IGroupsRepository groupsRepository)
        {
            _toDoTasksRepository = toDoTasksRepository;
            _groupsRepository = groupsRepository;
        }

        public Task AddTaskToGroup(int idTask, int idGroup)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(ToDoTask task)
        {
            if (task.GroupId is not null)
            {
                var groupExists = await _groupsRepository.GetByIdAsync(task.GroupId.Value);
                if (groupExists == null)
                    throw new KeyNotFoundException($"Group with ID {task.GroupId} not found.");

                task.Group = groupExists;
            }

            await _toDoTasksRepository.AddAsync(task);
        }


        public async Task DeleteAsync(int id)
        {
            if (!await _toDoTasksRepository.ExistsAsync(id))
                throw new Exception("Task not found");

            await _toDoTasksRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Models.ToDoTask>> GetAllAsync()
        {
            return await _toDoTasksRepository.GetAllAsync();
        }

        public async Task<Models.ToDoTask?> GetByIdAsync(int id)
        {
            return await _toDoTasksRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(ToDoTask toDoTask)
        {
            var existingTask = await _toDoTasksRepository.GetByIdAsync(toDoTask.Id);
            if (existingTask is null)
                throw new KeyNotFoundException("Task not found.");

            if (toDoTask.GroupId is not null)
            {
                var groupExists = await _groupsRepository.ExistsAsync(toDoTask.GroupId.Value);
                if (!groupExists)
                    throw new KeyNotFoundException("Group not found.");
            }

            await _toDoTasksRepository.UpdateAsync(toDoTask);
        }
    }
}
