using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ORDERsController : ControllerBase
    {
        private readonly BookContext _context;

        public ORDERsController(BookContext context)
        {
            _context = context;
        }

        // GET: api/ORDERs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ORDER>>> GetORDERs()
        {
            return await _context.ORDERs.ToListAsync();
        }

        // GET: api/ORDERs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ORDER>> GetORDER(int id)
        {
            var oRDER = await _context.ORDERs.FindAsync(id);

            if (oRDER == null)
            {
                return NotFound();
            }

            return oRDER;
        }

        // PUT: api/ORDERs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutORDER(int id, ORDER oRDER)
        {
            if (id != oRDER.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(oRDER).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ORDERExists(id))
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

        // POST: api/ORDERs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ORDER>> PostORDER(ORDER oRDER)
        {
            _context.ORDERs.Add(oRDER);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetORDER", new { id = oRDER.OrderId }, oRDER);
        }

        // DELETE: api/ORDERs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteORDER(int id)
        {
            var oRDER = await _context.ORDERs.FindAsync(id);
            if (oRDER == null)
            {
                return NotFound();
            }

            _context.ORDERs.Remove(oRDER);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ORDERExists(int id)
        {
            return _context.ORDERs.Any(e => e.OrderId == id);
        }
    }
}
