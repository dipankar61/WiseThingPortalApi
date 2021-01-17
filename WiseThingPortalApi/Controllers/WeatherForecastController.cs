using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiseThing.Data.Respository;

namespace WiseThingPortalApi.Controllers
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
        private readonly WisethingPortalContext context;
        private readonly IMapper _mapper;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,WisethingPortalContext context, IMapper mapper)
        {
            _logger = logger;
            this.context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            //var context = new WisethingPortalContext();
            //var output = context.Devices.SingleOrDefault(x=>x.DeviceId==1);
            //var model = _mapper.Map<DeviceDTO>(output);


            var rng = new Random();
            //var a = new Usertype();
            //a.UserTypeName = "Test";
            //context.Usertypes.Add(a);
            //context.SaveChanges();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
