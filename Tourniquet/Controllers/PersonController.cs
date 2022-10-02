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
        ILogger<PersonController> _logger;
        IPersonService _personService;
        public PersonController(IPersonService personService, ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
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
            _logger.LogInformation("Deneme Loglaması");
            return Ok(result);
        }
    }
}