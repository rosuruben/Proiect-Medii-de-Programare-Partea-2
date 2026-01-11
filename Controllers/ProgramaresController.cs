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
    public class ProgramaresController : ControllerBase
    {
        private readonly ClinicaVeterinaraP1Context _context;

        public ProgramaresController(ClinicaVeterinaraP1Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Programare>>> GetProgramare(int? medicId, int? proprietarId)
        {
            var query = _context.Programare
                .Include(p => p.Animal)
                .Include(p => p.MedicVeterinar)
                .AsQueryable();

            if (medicId.HasValue && medicId > 0)
            {
                query = query.Where(p => p.MedicVeterinarId == medicId.Value);
            }
            else if (proprietarId.HasValue && proprietarId > 0)
            {
                query = query.Where(p => p.Animal.ProprietarId == proprietarId.Value);
            }

            return await query.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Programare>> GetProgramare(int id)
        {
            var programare = await _context.Programare
                .Include(p => p.Animal)
                .Include(p => p.MedicVeterinar)
                .FirstOrDefaultAsync(m => m.ProgramareId == id);

            if (programare == null)
            {
                return NotFound();
            }

            return programare;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgramare(int id, Programare programare)
        {
            if (id != programare.ProgramareId)
            {
                return BadRequest();
            }

            _context.Entry(programare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramareExists(id))
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
        public async Task<ActionResult<Programare>> PostProgramare(Programare programare)
        {
            _context.Programare.Add(programare);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProgramare", new { id = programare.ProgramareId }, programare);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgramare(int id)
        {
            var programare = await _context.Programare.FindAsync(id);
            if (programare == null)
            {
                return NotFound();
            }

            _context.Programare.Remove(programare);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgramareExists(int id)
        {
            return _context.Programare.Any(e => e.ProgramareId == id);
        }
    }
}