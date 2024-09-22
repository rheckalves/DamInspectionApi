using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DamInspectionApi.Data;
using DamInspectionApi.Models;

namespace DamInspectionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DamsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Dams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dam>>> GetDams()
        {
            return await _context.Dams.ToListAsync();
        }

        // GET: api/Dams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dam>> GetDam(int id)
        {
            var dam = await _context.Dams.FindAsync(id);

            if (dam == null)
            {
                return NotFound();
            }

            return dam;
        }

        // PUT: api/Dams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDam(int id, Dam dam)
        {
            if (id != dam.Id)
            {
                return BadRequest();
            }

            _context.Entry(dam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DamExists(id))
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

        // POST: api/Dams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dam>> PostDam(Dam dam)
        {
            _context.Dams.Add(dam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDam", new { id = dam.Id }, dam);
        }

        // DELETE: api/Dams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDam(int id)
        {
            var dam = await _context.Dams.FindAsync(id);
            if (dam == null)
            {
                return NotFound();
            }

            _context.Dams.Remove(dam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DamExists(int id)
        {
            return _context.Dams.Any(e => e.Id == id);
        }
    }
}
