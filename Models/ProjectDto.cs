using System.Collections.Generic;

namespace trello.models
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ListDto>? Lists { get; set; }
    }

    public class ListDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<TaskDto>? Tasks { get; set; }
    }

    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CommentDto>? Comments { get; set; }
    }

    public class CommentDto
    {
        public int Id { get; set; }
        public string? Text { get; set; }
    }
}