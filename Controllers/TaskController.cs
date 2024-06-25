using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trello.Data;
using trello.models;

namespace trello.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TasksContext _context;

        public TasksController(TasksContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<MyTasks>>> GetAll()
        {
            var tasks = await _context.Tasks.ToListAsync();
            if (tasks == null) return NotFound();
            return tasks;
        }

        // Exemple d'une méthode avec validation et gestion d'erreur
        [HttpGet("list/{listId}")]
        public async Task<ActionResult<List<MyTasks>>> GetTasksByListId(int listId)
        {
            if (listId <= 0)
            {
                return BadRequest("Invalid list ID");
            }

            var tasks = await _context.Tasks.Where(t => t.ListId == listId).ToListAsync();

            if (!tasks.Any())
            {
                return NotFound($"No tasks found for list ID {listId}");
            }

            return tasks;
        }
    }
}