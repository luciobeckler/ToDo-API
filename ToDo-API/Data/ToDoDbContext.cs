using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ToDo_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ToDo_API.Data
{
    public class ToDoDbContext : IdentityDbContext<ApplicationUser>
    {
        public ToDoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ToDoTask> Tasks { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
