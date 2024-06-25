using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult<List<MyTasks>> GetAll()
        {
            return _context.Tasks.ToList();
        }

        [HttpGet("list/{listId}")]
        public ActionResult<List<MyTasks>> GetByList(int listId)
        {
            return _context.Tasks.Where(task => task.ListId == listId).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<MyTasks> GetById(int id)
        {
            var task = _context.Tasks.Find(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        [HttpPost]
        public async Task<ActionResult<MyTasks>> Create(MyTasks task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MyTasks task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
