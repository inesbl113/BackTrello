namespace trello.DTOs
{
    public class TaskDto
    {
         public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ListId { get; set; }

        public TaskDto()
        {
            CreatedAt = DateTime.Now;
        }
    }
}