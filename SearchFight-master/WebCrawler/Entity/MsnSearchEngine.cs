namespace WebCrawler
{
    public class MsnSearchEngine: SearchEngine
    {
        public MsnSearchEngine()
        {
            Name = "MSN";
            Link = "https://www.bing.com/search?q=";
            Selector = "class";
            SelectorName = "sb_count";
            SelectorHTMLTag = "span";
        }
    }
}
