using Microsoft.AspNetCore.Mvc;
using PeliculasApi.repositorios;

namespace PeliculasApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRepositorio _repositorioEnMemoria;

        public WeatherForecastController(IRepositorio repositorioEnMemoria, ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _repositorioEnMemoria = repositorioEnMemoria;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            
            var generos = _repositorioEnMemoria.ObtenerTodosLosGeneros();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
