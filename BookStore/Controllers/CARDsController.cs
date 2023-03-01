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
    public class CARDsController : ControllerBase
    {
        private readonly BookContext _context;

        public CARDsController(BookContext context)
        {
            _context = context;
        }

        // GET: api/CARDs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CARD>>> GetCARDs()
        {
            return await _context.CARDs.ToListAsync();
        }

        // GET: api/CARDs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CARD>> GetCARD(int id)
        {
            var cARD = await _context.CARDs.FindAsync(id);

            if (cARD == null)
            {
                return NotFound();
            }

            return cARD;
        }

        // PUT: api/CARDs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCARD(int id, CARD cARD)
        {
            if (id != cARD.CardID)
            {
                return BadRequest();
            }

            _context.Entry(cARD).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CARDExists(id))
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

        // POST: api/CARDs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CARD>> PostCARD(CARD cARD)
        {
            _context.CARDs.Add(cARD);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCARD", new { id = cARD.CardID }, cARD);
        }

        // DELETE: api/CARDs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCARD(int id)
        {
            var cARD = await _context.CARDs.FindAsync(id);
            if (cARD == null)
            {
                return NotFound();
            }

            _context.CARDs.Remove(cARD);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CARDExists(int id)
        {
            return _context.CARDs.Any(e => e.CardID == id);
        }
    }
}
