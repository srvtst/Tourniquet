using Business.Abstract;
using Entities.Concrate;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;

namespace Tourniquet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegister userForRegister)
        {
            var result = _personService.Register(userForRegister, userForRegister.Password);
            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLogin userForLogin)
        {
            var userToLogin = _personService.Login(userForLogin);
            
            var result = _personService.CreateToken(userToLogin);
            return Ok(result);
        }
    }
}