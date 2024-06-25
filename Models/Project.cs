namespace trello.models
{
    public class Projects
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public ICollection<Lists>? Lists { get; set; }

        public Projects()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
