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
    public class AuctionsController : ControllerBase
    {
        private readonly Context _context;

        public AuctionsController(Context context)
        {
            _context = context;
        }

        // GET: api/Auctions
        [HttpGet]
        public IEnumerable<Auction> GetAuctions()
        {
            return _context.Auctions;
        }

        // GET: api/Auctions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var auction = await _context.Auctions.FindAsync(id);

            if (auction == null)
            {
                return NotFound();
            }

            return Ok(auction);
        }

        // PUT: api/Auctions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuction([FromRoute] int id, [FromBody] Auction auction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != auction.AuctionID)
            {
                return BadRequest();
            }

            _context.Entry(auction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuctionExists(id))
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

        // POST: api/Auctions
        [HttpPost]
        public async Task<IActionResult> PostAuction([FromBody] Auction auction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Auctions.Add(auction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuction", new { id = auction.AuctionID }, auction);
        }

        // DELETE: api/Auctions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var auction = await _context.Auctions.FindAsync(id);
            if (auction == null)
            {
                return NotFound();
            }

            _context.Auctions.Remove(auction);
            await _context.SaveChangesAsync();

            return Ok(auction);
        }

        private bool AuctionExists(int id)
        {
            return _context.Auctions.Any(e => e.AuctionID == id);
        }
    }
}