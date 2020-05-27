using System;

namespace WebCrawler
{
    public interface ISearchEngine
    {
        String Name { get; set; } 
        String Link { get; set; }
        Int64 Results { get; set; }
        String Selector { get; set; }
        String SelectorName { get; set; }
        String SelectorHTMLTag { get; set; }
        String BuildQueryLink(String query);
    }
}
