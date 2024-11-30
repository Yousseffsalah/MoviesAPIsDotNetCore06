using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.PL.APIs.Errors;

namespace Movies.PL.APIs.Controllers
{
    [Route("error/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class ErrorController : ControllerBase
    {
        public IActionResult Error(int code)
        {
            return NotFound(new ApiResponse(code, "The EndPoint You are try to Get, Not Found"));
        }
    }
}
