using Models.Output;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services.Services
{
    public class ComparisonService : IComparisonService
    {
        public List<QueryResult> GetWinners(List<List<QueryResult>> queryResults, List<string> queries)
        {
            List<QueryResult> winners = new List<QueryResult>();
            foreach (string searchQuery in queries)
            {
                var winner = queryResults.SelectMany(resultList => resultList, 
                                         (resultList, queryResult) => queryResult)
                                         .Where(queryResult => queryResult.SearchTerm == searchQuery)
                                         .OrderByDescending(queryResult => queryResult.TotalResults)
                                         .FirstOrDefault();

                winners.Add(winner);
            }

            return winners;
        }
    }
}
