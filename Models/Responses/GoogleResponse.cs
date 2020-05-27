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
        public int TotalResults { get; set; }
    }


}
