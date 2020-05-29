using Bogus;
using Models.Output;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchFightTests.MockBuilders.ModelMocks
{
    internal static class QueryResultMock        
    {  
        internal async static Task<List<QueryResult>> GetBingResults()
        {
            var faker = new Faker<QueryResult>()
                             .RuleFor(o => o.SearchEngineUsed, f => "Bing")
                             .RuleFor(o => o.SearchTerm, f => "unit test")
                             .RuleFor(o => o.TotalResults, f => f.Random.ULong());

            return await Task.Run(() => faker.Generate(1));
        }

        internal async static Task<List<QueryResult>> GetGoogleResults()
        {
            var faker = new Faker<QueryResult>()
                              .RuleFor(o => o.SearchEngineUsed, f => "Google")
                              .RuleFor(o => o.SearchTerm, f => "unit test")
                              .RuleFor(o => o.TotalResults, f => f.Random.ULong());

            return await Task.Run(() => faker.Generate(1));
        }

        internal static List<QueryResult> GetWinnerResults(string winnerName)
        {            
            var faker = new Faker<QueryResult>()
                              .RuleFor(o => o.SearchEngineUsed, f => winnerName)
                              .RuleFor(o => o.SearchTerm, f => f.Random.Word())
                              .RuleFor(o => o.TotalResults, f => f.Random.ULong());

            return faker.Generate(1);
        }

        internal static List<QueryResult> GetBaseResults()
        {
            string[] searchEngines = { "Google", "Bing" };
            var faker = new Faker<QueryResult>()
                              .RuleFor(o => o.SearchEngineUsed, f => f.PickRandom<string>(searchEngines))
                              .RuleFor(o => o.SearchTerm, f => f.Random.Word())
                              .RuleFor(o => o.TotalResults, f => f.Random.ULong());

            return faker.Generate(1);
        }
     
    }
}

