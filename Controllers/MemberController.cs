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
    public class MemberController : ControllerBase
    {
        private readonly ConferenceContext _context;

        public MemberController(ConferenceContext context)
        {
            _context = context;
        }

        // GET: api/Member
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberItem>>> GetMemberItems()
        {
            return await _context.MemberItems.ToListAsync();
        }

        // GET: api/Member/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberItem>> GetMemberItem(long id)
        {
            var memberItem = await _context.MemberItems.FindAsync(id);

            if (memberItem == null)
            {
                return NotFound();
            }

            return memberItem;
        }

        // PUT: api/Member/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMemberItem(long id, MemberItem memberItem)
        {
            if (id != memberItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(memberItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberItemExists(id))
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

        // POST: api/Member
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MemberItem>> PostMemberItem(MemberItem memberItem)
        {
            _context.MemberItems.Add(memberItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMemberItem", new { id = memberItem.Id }, memberItem);
        }

        // DELETE: api/Member/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMemberItem(long id)
        {
            var memberItem = await _context.MemberItems.FindAsync(id);
            if (memberItem == null)
            {
                return NotFound();
            }

            _context.MemberItems.Remove(memberItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MemberItemExists(long id)
        {
            return _context.MemberItems.Any(e => e.Id == id);
        }
    }
}
