using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dexture.Models;
using Dexture.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dexture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandController : ControllerBase
    {

        private readonly IDataRepository<Prediction> _dataRepository;

        public LandController(IDataRepository<Prediction> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/Land
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Prediction> lands = _dataRepository.GetAll();
            return Ok(lands);
        }

        // GET: api/Land/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
           return Ok(_dataRepository.Getselected(id));
            
        }

        // POST: api/Land
        [HttpPost]
        public IActionResult Post([FromBody]  Prediction land)
        {
            _dataRepository.Add(land);
            return Ok();
        }

        // PUT: api/Land/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
