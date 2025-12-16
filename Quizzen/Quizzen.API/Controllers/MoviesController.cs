using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizzen.API.ApiResponse;

namespace Quizzen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        [HttpGet("")]
        [Authorize]
        public IActionResult Movies()
        {
            var movies = new List<string>
            {
                "The Shawshank Redemption",
                "The Godfather",
                "The Dark Knight",
                "Pulp Fiction",
                "Forrest Gump"
            };

            var response = new SuccessResponse<object?>(
                StatusCode: 200,
                Message: "Login successful.",
                Data: movies,
                Timestamp: DateTime.UtcNow
            );

            return Ok(response);
        }
    }
}
