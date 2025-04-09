namespace ToDo_API.Dtos
{
    public class ToDoTaskDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateOnly? StartDateTime { get; set; }
        public DateOnly? EndDateTime { get; set; }
        public int? GroupId { get; set; }
    }
}
