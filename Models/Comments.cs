using System;

namespace trello.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TaskId { get; set; }

        public Comments()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
