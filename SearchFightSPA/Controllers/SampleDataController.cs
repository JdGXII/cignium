using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Output;
using Services.Interfaces;

namespace SearchFightSPA.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private ISearchService _searchService;
        private IComparisonService _comparisonService;

        public SampleDataController(ISearchService searchService, IComparisonService comparisonService )
        {
            _searchService = searchService;
            _comparisonService = comparisonService;
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<QueryResult>> GetWinners()
        {
            var searchTerms = new List<string>() { "php", "java 8 help" };
            _searchService.SearchQueries = searchTerms;
            var temp = await _searchService.PerformGoogleSearch();
            var temp2 = await _searchService.PerformBingSearch();
            var winners = _comparisonService.GetWinners(new List<List<Models.Output.QueryResult>>() { temp, temp2 }, searchTerms);

            return winners;
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
