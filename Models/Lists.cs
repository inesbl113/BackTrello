namespace trello.models
{
    public class Lists
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ProjectId { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public Projects? Project { get; set; }
        public ICollection<MyTasks> Tasks { get; set; }
        public object Name { get; internal set; }

        public Lists()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
