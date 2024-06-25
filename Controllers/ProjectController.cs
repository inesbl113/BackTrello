using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trello.models;
using trello.Data; // Add the namespace for ProjectContext


namespace trello.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly TasksContext _context;

        public ProjectController(TasksContext context)
        {
            _context = context;
        }

        // GET: api/project
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Projects>>> GetProject()
        {
            return await _context.Projects.ToListAsync();
        }

        // GET: api/project/5
       [HttpGet("{id}")]
       public async Task<ActionResult<Projects>> GetProjectById(int id)
       {
         if (id <= 0)
           {
              return BadRequest("Invalid ID");
           }

         var project = await _context.Projects.FindAsync(id);

          if (project == null)
           {
              return NotFound();
            }

        return project;
       }

        // PUT: api/project/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, Projects project)
        {
            project.Id = id;

            if (id != project.Id)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/project
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Projects>> PostProject(Projects project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProject", new { id = project.Id }, project);
        }

        // DELETE: api/project/5

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}