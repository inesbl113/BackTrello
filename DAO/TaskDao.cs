using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trello.Data;
using trello.models;

namespace trello.Models
{
    public class TasksDao
    {
        private readonly TasksContext _context;

        public TasksDao(TasksContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MyTasks>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<MyTasks> GetTask(int id)
        {
          
            return await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<MyTasks> AddTask(MyTasks task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<MyTasks> UpdateTask(MyTasks task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
