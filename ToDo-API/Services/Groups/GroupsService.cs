using System.Security.Claims;
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
        public async Task<IEnumerable<Models.Group>> GetAllAsync(string userId)
        {
            var groups = await _groupsRepository.GetAllAsync();

            var userGroups = groups.Where(g => g.UserId == userId);
            return userGroups;
        }

        public async Task AddAsync(Models.Group group)
        {
            await _groupsRepository.AddAsync(group);
        }

        public async Task DeleteByIdAsync(int id, string userId)
        {
            if (!await _groupsRepository.ExistsAsync(id))
                throw new KeyNotFoundException("Group not found.");

            var group = await _groupsRepository.GetByIdAsync(id);
            bool groupBelongsToUser = group?.UserId == userId;
            
            if (!groupBelongsToUser)
                throw new InvalidOperationException("You do not have permission to delete this group.");

            await _groupsRepository.DeleteAsync(id);
        }

        public async Task<Models.Group?> GetById(int id, string userId)
        {
            var group = await _groupsRepository.GetByIdAsync(id);

            bool groupBelongsToUser = group?.UserId == userId;

            if (!groupBelongsToUser)
                throw new InvalidOperationException("You do not have permission to access this group.");

            return group;
        }

        public async Task UpdateAsync(Models.Group group)
        {
            if (!await _groupsRepository.ExistsAsync(group.Id))
                throw new KeyNotFoundException("Group not found.");

            var existingGroup = await _groupsRepository.GetByIdAsync(group.Id);
            if (existingGroup == null || existingGroup.UserId != group.UserId)
                throw new InvalidOperationException("Você não tem permissão para acessar este grupo.");

            await _groupsRepository.UpdateAsync(group);
        }
    }
}
