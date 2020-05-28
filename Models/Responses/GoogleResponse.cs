using System.Collections.Generic;

namespace Models.Responses
{
    public class GoogleResponse
    {
        public QueriesResponse Queries { get; set; }
    }

    public class QueriesResponse
    {
        public List<TotalResultsResponse> Request { get; set; }
    }

    public class TotalResultsResponse
    {
        public ulong TotalResults { get; set; }
        public string SearchTerms { get; set; }
    }


}
