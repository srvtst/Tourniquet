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

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _personService.GetAll();
            return Ok(result);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegister userForRegister)
        {
            var result = _personService.Register(userForRegister, userForRegister.Password);
            return Ok(result);
        }
    }
}