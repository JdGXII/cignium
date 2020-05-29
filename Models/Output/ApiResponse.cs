using System.Collections.Generic;

namespace Models.Output
{
    public class ApiResponse
    {
        public string Message { get; set; }
        public List<QueryResult> Results { get; set; }
        public List<QueryResult> Winners { get; set; }
    }
}
