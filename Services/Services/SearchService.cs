using ApiClients.Interfaces;
using Models.Output;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class SearchService : ISearchService
    {
        private readonly IGoogleClient _googleClient;
        public List<string> SearchQueries { get; set; }

        public SearchService(IGoogleClient googleClient)
        {
            _googleClient = googleClient;
        }

        public async Task<List<QueryResult>> PerformGoogleSearch()
        {
            var googleResponses = await _googleClient.GetResults(SearchQueries);

            var results = googleResponses.Select(googleResponse => googleResponse.Queries.Request
                                   .Select(result => new QueryResult
                                   {
                                       SearchTerm = result.SearchTerms,
                                       TotalResults = result.TotalResults
                                   })
                                   .FirstOrDefault())
                                   .ToList();

            return results;
        }
    }
}
