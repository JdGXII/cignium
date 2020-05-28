using Models.Output;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ISearchService
    {
        List<string> SearchQueries { get; set; }
        Task<List<QueryResult>> PerformGoogleSearch();
        Task<List<QueryResult>> PerformBingSearch();
    }
}
