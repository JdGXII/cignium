using Bogus;
using Models.Output;
using SearchFightTests.MockBuilders.ModelMocks;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFightTests.MockBuilders
{
    internal class SearchServiceMock : ISearchService
    {
        public List<string> SearchQueries { get; set; }

        public Task<List<QueryResult>> PerformBingSearch()
        {
            return QueryResultMock.GetBingResults();
        }

        public Task<List<QueryResult>> PerformGoogleSearch()
        {
            return QueryResultMock.GetGoogleResults();
        }

        internal static List<string> BuildSearchQueries()
        {
            Faker _faker = new Faker();

            return _faker.Random.WordsArray(3).ToList();
        }
    }
}
