using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieService.Abstractions;
using MovieService.DTOs;
using MovieService.Models;

namespace MovieService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MoviesController> _logger;
        private readonly IActorsDataClient _actorsDataClient;

        public MoviesController(IMovieRepository movieRepository,
            IMapper mapper,
            ILogger<MoviesController> logger,
            IActorsDataClient actorsDataClient)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _logger = logger;
            _actorsDataClient = actorsDataClient;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetAllMovies()
        {
            _logger.LogInformation("Getting all movies");

            try
            {
                var movies = await _movieRepository.GetMoviesAsync();

                return Ok(_mapper.Map<IEnumerable<MovieReadDTO>>(movies));
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex.Message);

                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetMovieById")]
        public async Task<ActionResult<MovieReadDTO>> GetMovieById(int id)
        {
            _logger.LogInformation("Getting movie with Id: {id}", id);

            try
            {
                var movie = await _movieRepository.GetMovieAsync(id);

                return Ok(_mapper.Map<MovieReadDTO>(movie));
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex.Message);

                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<MovieReadDTO>> CreateMovie(MovieWriteDTO movieWriteDTO)
        {
            _logger.LogInformation("Creating movie");

            var movie = _mapper.Map<Movie>(movieWriteDTO);

            await _movieRepository.CreateMovieAsync(movie);
            await _movieRepository.SaveChangesAsync();

            var movieReadDTO = _mapper.Map<MovieReadDTO>(movie);

            try
            {
                await _actorsDataClient.SendMovieToActor(movieReadDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Couldn't send synchronously");
            }

            return CreatedAtRoute(nameof(GetMovieById), new { Id = movieReadDTO.Id }, movieReadDTO);
        }
    }
}
