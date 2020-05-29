using ApiClients.Interfaces;
using Bogus;
using Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchFightTests.MockBuilders.ClientMocks
{
    public class GoogleMock : IGoogleClient
    {
        private Faker _faker = new Faker();
        public List<GoogleResponse> ExpectedResults { get; set; }

        public Task<List<GoogleResponse>> GetResults(List<string> queries)
        {
            BuildResults(queries);
            return Task.Run(() => ExpectedResults);
        }

        private void BuildResults(List<string> queries)
        {
            List<GoogleResponse> responses = new List<GoogleResponse>();
            foreach (string query in queries)
            {
                var response = new GoogleResponse()
                {
                    Queries = new QueriesResponse()
                    {
                        Request = new List<TotalResultsResponse>()
                        {
                            new TotalResultsResponse()
                            {
                            TotalResults = _faker.Random.ULong(),
                            SearchTerms = query
                            }
                        }
                    }
                };

                responses.Add(response);
            }

            ExpectedResults = responses;
        }
    }
}
