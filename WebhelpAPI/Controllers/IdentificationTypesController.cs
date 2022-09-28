using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebhelpAPI;
using WebhelpAPI.Data;

namespace WebhelpAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentificationTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public IdentificationTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/IdentificationTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentificationType>>> GetIdType()
        {
            return await _context.IdType.ToListAsync();
        }

        // GET: api/IdentificationTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IdentificationType>> GetIdentificationType(int id)
        {
            var identificationType = await _context.IdType.FindAsync(id);

            if (identificationType == null)
            {
                return NotFound();
            }

            return identificationType;
        }

        // PUT: api/IdentificationTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdentificationType(int id, IdentificationType identificationType)
        {
            if (id != identificationType.Id)
            {
                return BadRequest();
            }

            _context.Entry(identificationType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdentificationTypeExists(id))
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

        // POST: api/IdentificationTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IdentificationType>> PostIdentificationType(IdentificationType identificationType)
        {
            _context.IdType.Add(identificationType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIdentificationType", new { id = identificationType.Id }, identificationType);
        }

        // DELETE: api/IdentificationTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdentificationType(int id)
        {
            var identificationType = await _context.IdType.FindAsync(id);
            if (identificationType == null)
            {
                return NotFound();
            }

            _context.IdType.Remove(identificationType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IdentificationTypeExists(int id)
        {
            return _context.IdType.Any(e => e.Id == id);
        }
    }
}
