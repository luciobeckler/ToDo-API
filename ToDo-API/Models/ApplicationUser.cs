
using Microsoft.AspNetCore.Identity;

namespace ToDo_API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Group> Groups { get; set; } = new List<Group>();
    }
}
