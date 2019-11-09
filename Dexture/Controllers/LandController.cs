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

        private readonly IDataRepository<Land> _dataRepository;

        public LandController(IDataRepository<Land> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/Land
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Land> lands = _dataRepository.GetAll();
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
        public Boolean Post([FromBody]  Land land)
        {
            try
            {
                _dataRepository.Add(land);
                return true;
            }
            catch
            {
                return false;
            }
            
            
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
