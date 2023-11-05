using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using SignityQuest.Models;

namespace SignityQuest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBPreviousTasksController : ControllerBase
    {
        private readonly TasksDBContext _context;

        public DBPreviousTasksController(TasksDBContext context)
        {
            _context = context;
        }

        // GET: api/DBPreviousTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DBPreviousTasks>>> GetDBPreviousTasks()
        {
          if (_context.DBPreviousTasks == null)
          {
              return NotFound();
          }
            return await _context.DBPreviousTasks.ToListAsync();
        }

        // GET: api/DBPreviousTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DBPreviousTasks>> GetDBPreviousTasks(int id)
        {
          if (_context.DBPreviousTasks == null)
          {
              return NotFound();
          }
            var dBPreviousTasks = await _context.DBPreviousTasks.FindAsync(id);

            if (dBPreviousTasks == null)
            {
                return NotFound();
            }

            return dBPreviousTasks;
        }
        // GET: api/DBPreviousTasks/last
        [HttpGet("getlast")]
        public async Task<ActionResult<DBPreviousTasks>> GetLastDBPreviousTasks()
        {
            if (_context.DBPreviousTasks == null)
            {
                return NotFound();
            }
            int id = (from n in _context.DBPreviousTasks
                      orderby n.Id descending
                      select n.Id).FirstOrDefault();

            var dBPreviousTasks = await _context.DBPreviousTasks.FindAsync(id);


            if (dBPreviousTasks == null)
            {
                return NotFound();
            }

            return dBPreviousTasks;
        }

        // PUT: api/DBPreviousTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDBPreviousTasks(int id, DBPreviousTasks dBPreviousTasks)
        {
            if (id != dBPreviousTasks.Id)
            {
                return BadRequest();
            }

            _context.Entry(dBPreviousTasks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DBPreviousTasksExists(id))
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

        // POST: api/DBPreviousTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DBPreviousTasks>> PostDBPreviousTasks(taskFromFront tasks)
        {
            var dbTask = new DBPreviousTasks();
            dbTask.todaysDate = DateTime.Now;
            DayOfWeek dayOfWeek = new DayOfWeek();
            int count = 0;

            switch (tasks.day.ToLower())
            {
                case "mon":
                    dayOfWeek = DayOfWeek.Monday;
                    break;
                case "tue":
                    dayOfWeek = DayOfWeek.Tuesday;
                    break;
                case "wed":
                    dayOfWeek = DayOfWeek.Wednesday;
                    break;
                case "thu":
                    dayOfWeek = DayOfWeek.Thursday;
                    break;
                case "fri":
                    dayOfWeek = DayOfWeek.Friday;
                    break;
                case "sat":
                    dayOfWeek = DayOfWeek.Saturday;
                    break;
                case "sun":
                    dayOfWeek = DayOfWeek.Sunday;
                    break;
            }

            for (int i = 0; tasks.startingDate.DayOfWeek != dayOfWeek; i++)
            {
                tasks.startingDate = tasks.startingDate.AddDays(1);
            }
            dbTask.firstOccurrenceDate = tasks.startingDate;
            for (int i = 0; tasks.startingDate < DateTime.Now.AddDays(-7*tasks.interval); i++)
            {
                tasks.startingDate = tasks.startingDate.AddDays(7*tasks.interval);
                count++;
            }
            dbTask.previousOccurenceDate = tasks.startingDate;
            dbTask.nextOccurrenceDate = tasks.startingDate.AddDays(7 * tasks.interval);
            dbTask.count = count+1;
            //return Ok();

            if (_context.DBPreviousTasks == null)
            {
                return Problem("entity set 'tasksdbcontext.dbprevioustasks'  is null.");
            }
            _context.DBPreviousTasks.Add(dbTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDBPreviousTasks", new { id = dbTask.Id }, dbTask);

        }


        // DELETE: api/DBPreviousTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDBPreviousTasks(int id)
        {
            if (_context.DBPreviousTasks == null)
            {
                return NotFound();
            }
            var dBPreviousTasks = await _context.DBPreviousTasks.FindAsync(id);
            if (dBPreviousTasks == null)
            {
                return NotFound();
            }

            _context.DBPreviousTasks.Remove(dBPreviousTasks);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DBPreviousTasksExists(int id)
        {
            return (_context.DBPreviousTasks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
    public class taskFromFront
    {
        public int interval { get; set; }
        public DateTime startingDate { get; set; }
        public string day { get; set; }      
    }
}
