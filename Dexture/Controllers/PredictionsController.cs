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
    public class PredictionsController : ControllerBase
    {
        private readonly Context _context;

        public PredictionsController(Context context)
        {
            _context = context;
        }

        // GET: api/Predictions
        [HttpGet]
        public IEnumerable<Prediction> Getpredictions()
        {
            return _context.predictions;
        }

        // GET: api/Predictions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrediction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prediction = await _context.predictions.FindAsync(id);

            if (prediction == null)
            {
                return NotFound();
            }

            return Ok(prediction);
        }

        // PUT: api/Predictions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrediction([FromRoute] int id, [FromBody] Prediction prediction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prediction.PredictionID)
            {
                return BadRequest();
            }

            _context.Entry(prediction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PredictionExists(id))
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

        // POST: api/Predictions
        [HttpPost]
        public async Task<IActionResult> PostPrediction([FromBody] Prediction prediction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.predictions.Add(prediction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrediction", new { id = prediction.PredictionID }, prediction);
        }

        // DELETE: api/Predictions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrediction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prediction = await _context.predictions.FindAsync(id);
            if (prediction == null)
            {
                return NotFound();
            }

            _context.predictions.Remove(prediction);
            await _context.SaveChangesAsync();

            return Ok(prediction);
        }

        private bool PredictionExists(int id)
        {
            return _context.predictions.Any(e => e.PredictionID == id);
        }
    }
}