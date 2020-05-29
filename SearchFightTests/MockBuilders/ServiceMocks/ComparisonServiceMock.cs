using Models.Output;
using SearchFightTests.MockBuilders.ModelMocks;
using Services.Interfaces;
using System.Collections.Generic;

namespace SearchFightTests.MockBuilders
{
    internal class ComparisonServiceMock : IComparisonService
    {
        internal string WinnerName { get; set; }

        public List<QueryResult> GetBaseSearchResults(List<List<QueryResult>> queryResults, List<string> queries)
        {
            return QueryResultMock.GetBaseResults();
        }

        public List<QueryResult> GetWinners(List<List<QueryResult>> queryResults, List<string> queries)
        {
            return QueryResultMock.GetWinnerResults(WinnerName);
        }
    }
}
