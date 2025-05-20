using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToDo_API.Models
{
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }

        public List<ToDoTask> Tasks { get; set; } = new();

        [Required] 
        public string UserId { get; set; }

        [JsonIgnore]
        public ApplicationUser User { get; set; }
    }

}
