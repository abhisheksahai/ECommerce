using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseController
    {
        [HttpGet]
        public IActionResult GetBadRequest()
        {
            return BadRequest(new ProblemDetails { Title = "This is a bad request" });
        }

        [HttpGet]
        public IActionResult GetUnauthorized()
        {
            return Unauthorized();
        }

        [HttpGet]
        public IActionResult GetNotFound()
        {
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetValidationError()
        {
            ModelState.AddModelError("Problem1", "This is first error");
            ModelState.AddModelError("Problem2", "This is second error");
            return ValidationProblem();
        }

        [HttpGet]
        public IActionResult GetServerError()
        {
            throw new Exception("This is a server error");
        }

    }
}