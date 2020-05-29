using Models.Output;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IComparisonService
    {
        List<QueryResult> GetWinners(List<List<QueryResult>> queryResults, List<string> queries);
        List<QueryResult> GetAllSearchResults(List<List<QueryResult>> queryResults, List<string> queries);
    }
}
