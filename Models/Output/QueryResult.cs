namespace Models.Output
{
    public class QueryResult
    {
        public string SearchEngineUsed { get; set; }
        public string SearchTerm { get; set; }
        public ulong TotalResults { get; set; }        
    }
}
