using Microsoft.AspNetCore.Mvc;
using Negoci.Service;
using Negoci.DataAccess;
using Negoci.Models;
using System.Collections.Generic;
namespace EjemploAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [ApiController]
        public class SelladoraNombre : ControllerBase
        {
            [HttpPost]
            [Route("CheckUser")]
            public IActionResult CheckUser([FromBody] string codeUser)
            {
                try
                {
                    iClaseDAL iSelladora = new ClassDAL();
                    List<cUsuario> lst = new List<cUsuario>();
                    string sError = string.Empty;
                    bool verificarSelect = iSelladora.traerSelladora(ref sError, ref lst);
                    if (verificarSelect)
                    {
                        return Ok(new { sError, flag = true });
                    }
                    else
                    {
                        return NotFound(new { sError, flag = false });
                    }
                }
                catch (Exception ex)
                {
                    return Ok(new { sError = "Las credenciales son incorrectas", flag = false });
                }
            }
        }
    }
}
