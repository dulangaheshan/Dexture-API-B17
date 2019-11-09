using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Dexture.Models;
using Dexture.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Dexture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IDataRepository<Admin> _dataRepository;
        private IConfiguration _config;

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
                    string token = BuildToken(adminTOLogin);
                    return new JsonResult(new { token = token });
                   

                }
                else
                {
                    return BadRequest();
                }
            }

        }
        private string BuildToken(Admin user)
        {
            try
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Acr, user.AdminId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.FirstName),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    claims,
                   expires: DateTime.Now.AddMinutes(500),
                    // expires: DateTime.Now.AddHours(5),
                    signingCredentials: creds);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception e)
            {
                return e.ToString();
            }

            //return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
