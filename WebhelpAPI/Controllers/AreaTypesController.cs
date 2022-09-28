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
    public class AreaTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public AreaTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/AreaTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AreaType>>> GetAreaTypes()
        {
            return await _context.AreaTypes.ToListAsync();
        }

        // GET: api/AreaTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AreaType>> GetAreaType(int id)
        {
            var areaType = await _context.AreaTypes.FindAsync(id);

            if (areaType == null)
            {
                return NotFound();
            }

            return areaType;
        }

        // PUT: api/AreaTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAreaType(int id, AreaType areaType)
        {
            if (id != areaType.Id)
            {
                return BadRequest();
            }

            _context.Entry(areaType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaTypeExists(id))
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

        // POST: api/AreaTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AreaType>> PostAreaType(AreaType areaType)
        {
            _context.AreaTypes.Add(areaType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAreaType", new { id = areaType.Id }, areaType);
        }

        // DELETE: api/AreaTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAreaType(int id)
        {
            var areaType = await _context.AreaTypes.FindAsync(id);
            if (areaType == null)
            {
                return NotFound();
            }

            _context.AreaTypes.Remove(areaType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AreaTypeExists(int id)
        {
            return _context.AreaTypes.Any(e => e.Id == id);
        }
    }
}
