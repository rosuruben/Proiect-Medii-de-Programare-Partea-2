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
    public class MedicVeterinarsController : ControllerBase
    {
        private readonly ClinicaVeterinaraP1Context _context;

        public MedicVeterinarsController(ClinicaVeterinaraP1Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicVeterinar>>> GetMedicVeterinar()
        {
            return await _context.MedicVeterinar.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicVeterinar>> GetMedicVeterinar(int id)
        {
            var medicVeterinar = await _context.MedicVeterinar.FindAsync(id);

            if (medicVeterinar == null)
            {
                return NotFound();
            }

            return medicVeterinar;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicVeterinar(int id, MedicVeterinar medicVeterinar)
        {
            if (id != medicVeterinar.MedicVeterinarId)
            {
                return BadRequest();
            }

            _context.Entry(medicVeterinar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicVeterinarExists(id))
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
        public async Task<ActionResult<MedicVeterinar>> PostMedicVeterinar(MedicVeterinar medicVeterinar)
        {
            _context.MedicVeterinar.Add(medicVeterinar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicVeterinar", new { id = medicVeterinar.MedicVeterinarId }, medicVeterinar);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicVeterinar(int id)
        {
            var medicVeterinar = await _context.MedicVeterinar.FindAsync(id);
            if (medicVeterinar == null)
            {
                return NotFound();
            }

            _context.MedicVeterinar.Remove(medicVeterinar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicVeterinarExists(int id)
        {
            return _context.MedicVeterinar.Any(e => e.MedicVeterinarId == id);
        }
    }
}
