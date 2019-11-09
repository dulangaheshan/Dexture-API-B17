using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dexture.Models;
using Dexture.Models.Repository;
using Newtonsoft.Json;

namespace Dexture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HarvestsController : ControllerBase
    {
        private readonly Context _context;
        private readonly IDataRepository<Harvest> _datarepository;
        private readonly IDataRepository<Land_Harvest> _land_Hatvest_datarepository;
        private readonly IDataRepository<Land> _land;

        public HarvestsController(IDataRepository<Harvest> dataRepository, Context context, IDataRepository<Land_Harvest> land_harvest_Repository,IDataRepository<Land> land)
        {
            _datarepository = dataRepository;
            _land_Hatvest_datarepository = land_harvest_Repository;
            _land = land;
        }

        // GET: api/Harvests
        [HttpGet]
        public IEnumerable<Harvest> GetHarvest()
        {
            return _context.Harvests;
        }

        // GET: api/Harvests/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHarvest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var harvest = await _context.Harvests.FindAsync(id);

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
        public IActionResult PostHarvest([FromBody] dynamic harvest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //Harvest Data = harvest.First;
           
            var json = JsonConvert.SerializeObject(harvest.First);
            var harvestData = JsonConvert.DeserializeObject<Harvest>(json);
            var json2 = JsonConvert.SerializeObject(harvest.Last);
            var landId = JsonConvert.DeserializeObject<long>(json2);
            //var myCommandMessage = JsonConvert.DeserializeObject<Harvest>(harvest.First);
            long id =  _datarepository.AddData(harvestData);
           Land_Harvest land_harvest = new Land_Harvest();
            var lands = _land.Get(landId);
            land_harvest.Lands = lands;
            land_harvest.Harvests = harvestData;
          
           _land_Hatvest_datarepository.Add(land_harvest);
           
            

            return CreatedAtAction("GetHarvest", new { id = harvestData.HarvestId }, harvestData);
        }

        // DELETE: api/Harvests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHarvest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var harvest = await _context.Harvests.FindAsync(id);
            if (harvest == null)
            {
                return NotFound();
            }

            _context.Harvests.Remove(harvest);
            await _context.SaveChangesAsync();

            return Ok(harvest);
        }

        private bool HarvestExists(int id)
        {
            return _context.Harvests.Any(e => e.HarvestId == id);
        }
    }
}