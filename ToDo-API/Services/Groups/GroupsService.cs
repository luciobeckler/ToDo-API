using ToDo_API.Repositorys.Groups;
using ToDo_API.Repositorys.ToDoTasks;

namespace ToDo_API.Services.Groups
{
    public class GroupsService : IGroupsService
    {
        private readonly IGroupsRepository _groupsRepository;
        public GroupsService(IGroupsRepository groupsRepository)
        {
            _groupsRepository = groupsRepository;
        }

        public async Task AddAsync(Models.Group group)
        {
            await _groupsRepository.AddAsync(group);
        }
        public async Task DeleteAsync(int id)
        {
            if (!await _groupsRepository.ExistsAsync(id))
                throw new KeyNotFoundException("Group not found");

            await _groupsRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Models.Group>> GetAllAsync()
        {
            return await _groupsRepository.GetAllAsync();
        }

        public async Task<Models.Group?> GetByIdAsync(int id)
        {
            return await _groupsRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Models.Group group)
        {
            if (!await _groupsRepository.ExistsAsync(group.Id))
                throw new KeyNotFoundException("Group not found");

            await _groupsRepository.UpdateAsync(group);
        }
    }
}
