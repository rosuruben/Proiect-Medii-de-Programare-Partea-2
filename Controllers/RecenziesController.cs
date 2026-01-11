using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaVeterinaraAPI.Data;
using ClinicaVeterinaraAPI.Models;

namespace ClinicaVeterinaraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecenziesController : ControllerBase
    {
        private readonly ClinicaVeterinaraP1Context _context;

        public RecenziesController(ClinicaVeterinaraP1Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recenzie>>> GetRecenzie()
        {
            return await _context.Recenzie
                .Include(r => r.Proprietar)
                .Include(r => r.MedicVeterinar)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recenzie>> GetRecenzie(int id)
        {
            var recenzie = await _context.Recenzie
                .Include(r => r.Proprietar)
                .Include(r => r.MedicVeterinar)
                .FirstOrDefaultAsync(m => m.RecenzieId == id);

            if (recenzie == null)
            {
                return NotFound();
            }

            return recenzie;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecenzie(int id, Recenzie recenzie)
        {
            if (id != recenzie.RecenzieId)
            {
                return BadRequest();
            }

            _context.Entry(recenzie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecenzieExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Recenzie>> PostRecenzie(Recenzie recenzie)
        {
            _context.Recenzie.Add(recenzie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecenzie", new { id = recenzie.RecenzieId }, recenzie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecenzie(int id)
        {
            var recenzie = await _context.Recenzie.FindAsync(id);
            if (recenzie == null)
            {
                return NotFound();
            }

            _context.Recenzie.Remove(recenzie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecenzieExists(int id)
        {
            return _context.Recenzie.Any(e => e.RecenzieId == id);
        }
    }
}
