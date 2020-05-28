using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Output
{
    public class QueryResult
    {
        public string SearchTerm { get; set; }
        public ulong TotalResults { get; set; }        
    }
}
