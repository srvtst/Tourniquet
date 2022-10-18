using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Tourniquet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourniquetController : ControllerBase
    {
        ITourniquetService _tourniquetService;
        public TourniquetController(ITourniquetService tourniquetService)
        {
            _tourniquetService = tourniquetService;
        }

        //[Authorize]
        [HttpPost("entry")]
        public IActionResult Entry(Entities.Concrate.Tourniquet tourniquet)
        {
            _tourniquetService.Entry(tourniquet);
            return Ok("Turnikeden Giriş Yapıldı");
        }

        //[Authorize]
        [HttpPost("exit")]
        public IActionResult Exit(Entities.Concrate.Tourniquet tourniquet)
        {
            _tourniquetService.Exit(tourniquet);

            return Ok("Turnikeden Çıkış Yapıldı");
        }

        //[Authorize]
        [HttpGet("getDay")]
        public IActionResult GetDayTourniquet(DateTime dateTime)
        {
            var result = _tourniquetService.GetDayTourniquet(dateTime);
            return Ok(result);
        }

        //[Authorize]
        [HttpGet("getMonth")]
        public IActionResult GetMonthTourniquet(DateTime dateTime)
        {
            var result = _tourniquetService.GetMonthTourniquet(dateTime);
            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _tourniquetService.GetAll();
            return Ok(result);
        }
    }
}