using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DotnetCore2.DBL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


namespace DotnetCore2.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        HttpClientHandler _clienthandler = new HttpClientHandler();

        private readonly ILogger<WeatherForecastController> _logger;

        private IEmployeesService _IEmployeesService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IEmployeesService IEmployeeservice)
        {
            _IEmployeesService = IEmployeeservice;

            _logger = logger;
            _clienthandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        //-api data

        //[EnableCors("ApiPolicy")]
        public async Task<string> GetApiApproval()
        {
            string apiResponse = null;
            using (var _httpclient= new HttpClient(_clienthandler))
            {
                // Receiving approval from dotnetcore / Normal Webapiout project
                using (var _response = await _httpclient.GetAsync("http://localhost:60450/Home/about"))
                {
                     apiResponse = await _response.Content.ReadAsStringAsync();
                    //emplist  = JsonConvert.DeserializeObject<List<Employees>()apiResponse();
                }
            }

            return apiResponse;
        }
    }
}
