using System;

namespace WebCrawler
{
    public interface ICrawler
    {
        SearchResult Search(ISearchEngine crawler, String query);
    }
}
