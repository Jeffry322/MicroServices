using Microsoft.AspNetCore.Mvc;

namespace ActorsService.Controllers
{
    [Route("api/actors/[controller]")]
    public sealed class MoviesController : ControllerBase
    {
        public MoviesController()
        {
            
        }

        [HttpPost]
        public ActionResult GetMovies()
        {
            Console.WriteLine("Returning OK from Actors Service");

            return Ok("Returning OK from Actors Service");
        }
    }
}
