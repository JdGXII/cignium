using ErrorHandling.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchFightWeb.Controllers
{
    public class DefaultController : Controller
    {
        private ISearchService _searchService;
        private IComparisonService _comparisonService;
        public DefaultController(ISearchService queryService, IComparisonService comparisonService)
        {
            _searchService = queryService;
            _comparisonService = comparisonService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var searchTerms = new List<string>() { "php", "java 8 help" };
                _searchService.SearchQueries = searchTerms;
                var temp = await _searchService.PerformGoogleSearch();
                var temp2 = await _searchService.PerformBingSearch();
                var winners = _comparisonService.GetWinners(new List<List<Models.Output.QueryResult>>() { temp, temp2 }, searchTerms);
            }
            catch (EmptyQueryException e)
            {
                ViewBag.Error = e.Message;
            }

            return View();
        }
    }
}
