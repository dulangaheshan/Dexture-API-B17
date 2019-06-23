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
    public class AdminController : ControllerBase
    {
        private readonly IDataRepository<Admin> _dataRepository;

        public AdminController(IDataRepository<Admin> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/Admin
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Admin/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Admin
        [HttpPost]
        public IActionResult Post([FromBody] Admin admin)
        {
            Admin adminTOReg = _dataRepository.Get(admin.Email);
            if (adminTOReg == null)
            {
                _dataRepository.Add(admin);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        // PUT: api/Admin/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("login")]
        public IActionResult login([FromBody]Login login)
        {
            Admin adminTOLogin = _dataRepository.Get(login.Email);
            if (adminTOLogin == null)
            {
                return BadRequest();
            }
            else
            {
                if (adminTOLogin.Password == login.Password)
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
