using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}

/*
 * namespace WebApplication1.Data.Configuration
{
    public class AwardConfiguration : IEntityTypeConfiguration<Award>
    {
        public void Configure(EntityTypeBuilder<Award> builder)
        {
            
            //builder.HasKey(x => x.ID);
            //builder.Property(x => x.ID).ValueGeneratedOnAdd();
            
            builder.HasOne(x => x.Holding).WithMany(x => x.Awards).HasForeignKey(x => x.HoldingId);


            builder.HasOne(x => x.Notification).WithOne(x => x.Award);


            builder.HasDiscriminator<string>("AwardType").HasValue<ProducerAward>("Producer").HasValue<RoleAward>("Role").HasValue<MovieAward>("Movie");
            
        }
    }
}
 * 
 * */