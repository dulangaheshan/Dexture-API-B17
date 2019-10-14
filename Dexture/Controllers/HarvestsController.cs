using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dexture.Models;
using Dexture.Models.Repository;

namespace Dexture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HarvestsController : ControllerBase
    {
        private readonly Context _context;

        public HarvestsController(Context context)
        {
            _context = context;
        }

        // GET: api/Harvests
        [HttpGet]
        public IEnumerable<Harvest> GetHarvest()
        {
            return _context.Harvest;
        }

        // GET: api/Harvests/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHarvest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var harvest = await _context.Harvest.FindAsync(id);

            if (harvest == null)
            {
                return NotFound();
            }

            return Ok(harvest);
        }

        // PUT: api/Harvests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHarvest([FromRoute] int id, [FromBody] Harvest harvest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != harvest.HarvestId)
            {
                return BadRequest();
            }

            _context.Entry(harvest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HarvestExists(id))
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

        // POST: api/Harvests
        [HttpPost]
        public async Task<IActionResult> PostHarvest([FromBody] Harvest harvest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Harvest.Add(harvest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHarvest", new { id = harvest.HarvestId }, harvest);
        }

        // DELETE: api/Harvests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHarvest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var harvest = await _context.Harvest.FindAsync(id);
            if (harvest == null)
            {
                return NotFound();
            }

            _context.Harvest.Remove(harvest);
            await _context.SaveChangesAsync();

            return Ok(harvest);
        }

        private bool HarvestExists(int id)
        {
            return _context.Harvest.Any(e => e.HarvestId == id);
        }
    }
}