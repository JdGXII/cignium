using System;

namespace WebCrawler
{
    public abstract class SearchEngine : ISearchEngine
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public long Results { get; set; }
        public string Selector { get; set; }
        public string SelectorName { get; set; }
        public string SelectorHTMLTag { get; set; }
        
        string ISearchEngine.BuildQueryLink(string query)
        {
            return String.Format("{0},{1}", Link,query);
        }
        
    }
}
