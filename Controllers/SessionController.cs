using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using that_us_tx24.Models;

namespace that_us_tx24.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ConferenceContext _context;

        public SessionController(ConferenceContext context)
        {
            _context = context;
        }

        // GET: api/Session
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SessionItem>>> GetSessionItems()
        {
            return await _context.SessionItems.ToListAsync();
        }

        // GET: api/Session/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SessionItem>> GetSessionItem(long id)
        {
            var sessionItem = await _context.SessionItems.FindAsync(id);

            if (sessionItem == null)
            {
                return NotFound();
            }

            return sessionItem;
        }

        // PUT: api/Session/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSessionItem(long id, SessionItem sessionItem)
        {
            if (id != sessionItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(sessionItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionItemExists(id))
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

        // POST: api/Session
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SessionItem>> PostSessionItem(SessionItem sessionItem)
        {
            _context.SessionItems.Add(sessionItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSessionItem", new { id = sessionItem.Id }, sessionItem);
        }

        // DELETE: api/Session/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSessionItem(long id)
        {
            var sessionItem = await _context.SessionItems.FindAsync(id);
            if (sessionItem == null)
            {
                return NotFound();
            }

            _context.SessionItems.Remove(sessionItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SessionItemExists(long id)
        {
            return _context.SessionItems.Any(e => e.Id == id);
        }
    }
}