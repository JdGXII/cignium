namespace WebCrawler
{
    public class GoogleSearchEngine : SearchEngine
    {
        public GoogleSearchEngine()
        {
            Name = "Google";
            Link = "https://www.google.com/search?q=";
            Selector = "Id";
            SelectorName = "resultStats";
            SelectorHTMLTag = "div";
           
        }
        
    }
}
