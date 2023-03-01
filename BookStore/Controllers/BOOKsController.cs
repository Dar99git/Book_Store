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
    public class BOOKsController : ControllerBase
    {
        private readonly BookContext _context;

        public BOOKsController(BookContext context)
        {
            _context = context;
        }

        // GET: api/BOOKs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BOOK>>> GetBOOKs()
        {
            return await _context.BOOKs.ToListAsync();
        }

        // GET: api/BOOKs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BOOK>> GetBOOK(int id)
        {
            var bOOK = await _context.BOOKs.FindAsync(id);

            if (bOOK == null)
            {
                return NotFound();
            }

            return bOOK;
        }

        // PUT: api/BOOKs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBOOK(int id, BOOK bOOK)
        {
            if (id != bOOK.BookId)
            {
                return BadRequest();
            }

            _context.Entry(bOOK).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BOOKExists(id))
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

        // POST: api/BOOKs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BOOK>> PostBOOK(BOOK bOOK)
        {
            _context.BOOKs.Add(bOOK);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBOOK", new { id = bOOK.BookId }, bOOK);
        }

        // DELETE: api/BOOKs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBOOK(int id)
        {
            var bOOK = await _context.BOOKs.FindAsync(id);
            if (bOOK == null)
            {
                return NotFound();
            }

            _context.BOOKs.Remove(bOOK);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BOOKExists(int id)
        {
            return _context.BOOKs.Any(e => e.BookId == id);
        }
    }
}
