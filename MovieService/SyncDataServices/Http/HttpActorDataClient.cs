using MovieService.Abstractions;
using MovieService.DTOs;
using System.Text;
using System.Text.Json;

namespace MovieService.SyncDataServices.Http
{
    public class HttpActorDataClient : IActorsDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HttpActorDataClient> _logger;
        private readonly IConfiguration _config;

        public HttpActorDataClient(HttpClient httpClient,
            ILogger<HttpActorDataClient> logger,
            IConfiguration config)
        {
            _httpClient = httpClient;
            _logger = logger;
            _config = config;
        }

        public async Task SendMovieToActor(MovieReadDTO movieReadDTO)
        {
            var httpContent = new StringContent(JsonSerializer.Serialize(movieReadDTO), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_config["ActorsService"], httpContent);

            if(response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Sync POST to Actors was OK!");
            } 
            else
            {
                _logger.LogInformation("Sync POST to Actors was NOT OK!");
            }
        }
    }
}
