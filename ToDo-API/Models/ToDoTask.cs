using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ToDo_API.Models
{
    public class ToDoTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateOnly? StartDateTime { get; set; }
        public DateOnly? EndDateTime { get; set; }


        public int? GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
