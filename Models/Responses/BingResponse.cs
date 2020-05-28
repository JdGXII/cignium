namespace Models.Responses
{
    public class BingResponse
    {
        public QueryContextField QueryContext { get; set; }
        public WebPagesField WebPages { get; set; }
    }

    public class QueryContextField
    {
        public string OriginalQuery { get; set; }
    }

    public class WebPagesField
    {
        public ulong TotalEstimatedMatches { get; set; }
    }
}
