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
    public class FutureCultivationsController : ControllerBase
    {
        private readonly IDataRepository<FutureCultivation> _dataRepository;

        public FutureCultivationsController(IDataRepository<FutureCultivation> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/FutureCultivations
        //[HttpGet]
        //public IEnumerable<FutureCultivation> GetFutureCultivation()
        //{
        //    return "gvsgv";
        //}

        // GET: api/FutureCultivations/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetFutureCultivation([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var futureCultivation = await _context.FutureCultivation.FindAsync(id);

        //    if (futureCultivation == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(futureCultivation);
        //}

        // PUT: api/FutureCultivations/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutFutureCultivation([FromRoute] int id, [FromBody] FutureCultivation futureCultivation)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != futureCultivation.CultivationId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(futureCultivation).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FutureCultivationExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/FutureCultivations
        [HttpPost]
        public IActionResult PostFutureCultivation([FromBody] FutureCultivation futureCultivation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dataRepository.Add(futureCultivation);
            return new OkResult();
        }

        //// DELETE: api/FutureCultivations/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteFutureCultivation([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var futureCultivation = await _context.FutureCultivation.FindAsync(id);
        //    if (futureCultivation == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.FutureCultivation.Remove(futureCultivation);
        //    await _context.SaveChangesAsync();

        //    return Ok(futureCultivation);
        //}

        //private bool FutureCultivationExists(int id)
        //{
        //    return _context.FutureCultivation.Any(e => e.CultivationId == id);
        //}
    }
}