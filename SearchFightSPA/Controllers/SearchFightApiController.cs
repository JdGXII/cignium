using System.Collections.Generic;
using System.Threading.Tasks;
using ErrorHandling.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Models.Output;
using Services.Interfaces;

namespace SearchFightSPA.Controllers
{
    [Route("api/[controller]")]
    public class SearchFightApiController : Controller
    {
        private ISearchService _searchService;
        private IComparisonService _comparisonService;

        public SearchFightApiController(ISearchService searchService, IComparisonService comparisonService)
        {
            _searchService = searchService;
            _comparisonService = comparisonService;
        }

        [HttpGet("[action]")]
        public async Task<ApiResponse> GetAllResults(List<string> searchTerms)
        {
            try
            {
                _searchService.SearchQueries = searchTerms;
                var googleResults = await _searchService.PerformGoogleSearch();
                var bingResults = await _searchService.PerformBingSearch();

                var allResults = _comparisonService.GetAllSearchResults(new List<List<QueryResult>>() { googleResults, bingResults }, searchTerms);

                return new ApiResponse { Message = "Succes", Results = allResults }; ;

            }
            catch (EmptyQueryException)
            {
                return new ApiResponse { Message = "You didn't input any search terms" };
            }
        }

        [HttpGet("[action]")]
        public async Task<ApiResponse> GetWinners(List<string> searchTerms)
        {
            try
            {
                _searchService.SearchQueries = searchTerms;
                var googleResults = await _searchService.PerformGoogleSearch();
                var bingResults = await _searchService.PerformBingSearch();
                var winners = _comparisonService.GetWinners(new List<List<QueryResult>>() { googleResults, bingResults }, searchTerms);

                return new ApiResponse { Message = "Succes", Results = winners }; ;
            }
            catch (EmptyQueryException)
            {
                return new ApiResponse { Message = "You didn't input any search terms" };
            }
        }
    }
}
