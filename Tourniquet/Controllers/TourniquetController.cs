using Business.Abstract;
using DataAccess.Abstract;
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

        //[HttpPost("entry")]
        //public IActionResult Entry(Tourniquet tourniquet)
        //{
        //    _tourniquetService.Entry(tourniquet);
        //    return Ok(tourniquet);
        //}
    }
}