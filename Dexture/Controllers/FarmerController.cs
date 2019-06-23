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
    public class FarmerController : ControllerBase
    {

        private readonly IDataRepository<Farmer> _datarepository;


        public FarmerController(IDataRepository<Farmer> dataRepository)
        {
            _datarepository = dataRepository;
        }
            
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Farmer> farmers = _datarepository.GetAll();
            return Ok(farmers);
        }

        [HttpPost]

        public IActionResult Post([FromBody] Farmer farmer)
        {
            Farmer farmerTOLogin = _datarepository.Get(farmer.Email);
            if (farmerTOLogin == null)
            {
                _datarepository.Add(farmer);
                return new OkResult();
            }
            else
            {
                return new ConflictResult();
            }

           
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAccpeted(long id,[FromBody]Farmer farmer)
        {
            Farmer farmerToUpdate = _datarepository.Get(id);
            _datarepository.Update(farmerToUpdate, farmer);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult login([FromBody]Login login)
        {
            Farmer farmerTOLogin = _datarepository.Get(login.Email);
            if(farmerTOLogin == null)
            {
                return BadRequest();
            }
            else
            {
                if(farmerTOLogin.Password == login.Password)
                {
                    return Ok();

                }
                else
                {
                    return BadRequest();
                }
            }
        }





    }
}