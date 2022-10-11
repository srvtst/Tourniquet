using Business.Abstract;
using Core.RabbitMQ.Abstract;
using DataAccess.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Http;
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

        [HttpPost("entry")]
        public IActionResult Entry(Entities.Concrate.Tourniquet tourniquet)
        {
            _tourniquetService.Entry(tourniquet);
            return Ok("Turnikeden Giriş Yapıldı");
        }

        [HttpPost("exit")]
        public IActionResult Exit(Entities.Concrate.Tourniquet tourniquet)
        {
            _tourniquetService.Exit(tourniquet);
            return Ok("Turnikeden Çıkış Yapıldı");
        }
    }
}