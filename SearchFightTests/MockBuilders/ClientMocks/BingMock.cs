using ApiClients.Interfaces;
using Bogus;
using Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchFightTests.MockBuilders.ClientMocks
{
    public class BingMock : IBingClient
    {
        private Faker _faker = new Faker();
        public List<BingResponse> ExpectedResults;

        public Task<List<BingResponse>> GetResults(List<string> queries)
        {
            BuildResults(queries);
            return Task.Run(() => ExpectedResults);
        }

        private void BuildResults(List<string> queries)
        {
            List<BingResponse> responses = new List<BingResponse>();
            foreach (string query in queries)
            {
                var response = new BingResponse
                {
                    QueryContext = new QueryContextField
                    {
                        OriginalQuery = query
                    },

                    WebPages = new WebPagesField
                    {
                        TotalEstimatedMatches = _faker.Random.ULong()
                    }
                };

                responses.Add(response);
            }

            ExpectedResults = responses;
        }
    }
}
