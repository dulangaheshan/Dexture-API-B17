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
    public class FarmerController : ControllerBase
    {

        private readonly IDataRepository<Farmer> _datarepository;
        private IConfiguration _config;

        public FarmerController(IDataRepository<Farmer> dataRepository,IConfiguration config)
        {
            _datarepository = dataRepository;
            _config = config;
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
                if(farmerTOLogin.Password == login.Password  && farmerTOLogin.IsAccepted == true)
                {
                    string token = BuildToken(farmerTOLogin);
                    return new JsonResult(new { token= token });

                }
                else if(farmerTOLogin.Password == login.Password && farmerTOLogin.IsAccepted == false)
                {
                    return new JsonResult(new { accepted = false });
                }
                else
                {
                    return BadRequest();
                }
            }
        }


        private string BuildToken(Farmer user)
        {
            try
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Acr, user.FarmerId.ToString()),
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