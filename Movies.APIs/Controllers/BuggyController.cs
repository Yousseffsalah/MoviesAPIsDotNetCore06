using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.DAL.Data.Entites;
using Movies.PL.APIs.Errors;

namespace Movies.PL.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {


        [HttpGet("NotFound")]
        public ActionResult NotFoundRequest()
        {
            return NotFound(new ApiResponse(404));

        }

        [HttpGet("serverError")]
        public ActionResult serverError()
        {


            var movei = "ddd";
            var value = int.Parse(movei);
            return Ok();

        }


        [HttpGet("badrequest")]
        public ActionResult BadRequestE()
        {

            return BadRequest(new ApiResponse(400));

        }

        [HttpGet("badrequest/{id}")]
        public ActionResult BadRequestE(int id)
        {

            return BadRequest();

        }



    }
}
