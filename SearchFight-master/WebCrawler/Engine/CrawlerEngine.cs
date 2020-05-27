using HtmlAgilityPack;
using System;
using System.IO;
using System.Linq;
using System.Net;

namespace WebCrawler
{
    public class CrawlerEngine: ICrawler
    {
        public SearchResult Search(ISearchEngine crawler, String query)
        {
            try
            {
                String result = String.Empty;
                HttpWebRequest requests = (HttpWebRequest)HttpWebRequest.Create(String.Format("{0}", crawler.BuildQueryLink(query)));
                
                WebResponse providedResponse = requests.GetResponse();
                Stream stream = providedResponse.GetResponseStream();
                StreamReader readInformation = new StreamReader(stream);
                string htmlOutput = readInformation.ReadToEnd();

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(htmlOutput);
                var element = htmlDocument.DocumentNode
                            .Descendants(crawler.SelectorHTMLTag)
                            .Where(node => node.GetAttributeValue(crawler.Selector, "")
                            .Equals(crawler.SelectorName))
                            .ToList();

                foreach (String item in element[0].InnerHtml.Split(' '))
                {
                    if (item.Any(char.IsDigit))
                    {
                        result = item.Replace(",", "").Replace(".", "");
                        break;
                    }
                }
            
                return new SearchResult() {
                    Query= query
                    ,Engine=crawler.Name
                    ,Value=Convert.ToInt64(result)
                };
            }
            catch (Exception e)
            {
                throw new ArgumentException("Something went wrong. "+e.Message);
            }

            
        }
        
    }
}
