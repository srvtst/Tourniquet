using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tourniquet.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class TourniquetController : ControllerBase
    {
        ITourniquetService _tourniquetService;
        public TourniquetController(ITourniquetService tourniquetService)
        {
            _tourniquetService = tourniquetService;
        }

        [HttpPost("entry")]
        public IActionResult Entry(Entities.Concrate.Tourniquet tourniquet)
        {
            var result = _tourniquetService.Entry(tourniquet);
            return Ok(result);
        }

        [HttpPost("exit")]
        public IActionResult Exit(Entities.Concrate.Tourniquet tourniquet)
        {
            var result = _tourniquetService.Exit(tourniquet);
            return Ok(result);
        }

        [HttpGet("getDay")]
        public IActionResult GetDayTourniquet(DateTime dateTime)
        {
            var result = _tourniquetService.GetDayTourniquet(dateTime);
            return Ok(result);
        }

        [HttpGet("getMonth")]
        public IActionResult GetMonthTourniquet(DateTime dateTime)
        {
            var result = _tourniquetService.GetMonthTourniquet(dateTime);
            return Ok(result);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _tourniquetService.GetAll();
            return Ok(result);
        }

        [HttpGet("getByTourniquet")]
        public IActionResult GetByTourniquet(int id)
        {
            var result = _tourniquetService.GetByTourniquet(id);
            return Ok(result);
        }
    }
}