using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using trello.Models;

namespace trello.models
{
    public class MyTasks
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ListId { get; set; }
        public bool IsCompleted { get; set; } 

        [ForeignKey("ListId")]
        public Lists? List { get; set; } 
        public ICollection<Comments> Comments { get; set; } 
        public MyTasks()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
