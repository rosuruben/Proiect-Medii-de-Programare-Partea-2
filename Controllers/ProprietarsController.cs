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
    public class ProprietarsController : ControllerBase
    {
        private readonly ClinicaVeterinaraP1Context _context;

        public ProprietarsController(ClinicaVeterinaraP1Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proprietar>>> GetProprietar()
        {
            return await _context.Proprietar.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Proprietar>> GetProprietar(int id)
        {
            var proprietar = await _context.Proprietar.FindAsync(id);

            if (proprietar == null)
            {
                return NotFound();
            }

            return proprietar;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProprietar(int id, Proprietar proprietar)
        {
            if (id != proprietar.ProprietarId)
            {
                return BadRequest();
            }

            _context.Entry(proprietar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProprietarExists(id))
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
        public async Task<ActionResult<Proprietar>> PostProprietar(Proprietar proprietar)
        {
            _context.Proprietar.Add(proprietar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProprietar", new { id = proprietar.ProprietarId }, proprietar);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProprietar(int id)
        {
            var proprietar = await _context.Proprietar.FindAsync(id);
            if (proprietar == null)
            {
                return NotFound();
            }

            _context.Proprietar.Remove(proprietar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProprietarExists(int id)
        {
            return _context.Proprietar.Any(e => e.ProprietarId == id);
        }
    }
}
