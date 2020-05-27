using System;
using System.Collections.Generic;
using System.Linq;

namespace WebCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                EvaluateSearchKey(args);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Something went wrong. " + e.Message);
            }
            Console.ReadLine();
        }
        
        private static void EvaluateSearchKey(string[] queries)
        {
            ICrawler crawler = new CrawlerEngine();

            string[] distinctQueries = queries.Distinct().ToArray();
            
            if (distinctQueries.Length != queries.Length)
                Console.WriteLine("More than one item is repeated in the search list. I will search it anyway, based on distincts");

            Dictionary<string, Dictionary<string, Int64>> totals = new Dictionary<string, Dictionary<string, long>>();

            List<ISearchEngine> engineList = GetEngines();
            foreach (ISearchEngine item in engineList)
            {
                Dictionary<string, Int64> querySearch = new Dictionary<string, long>();
                for (int i = 0; i < distinctQueries.Length; i++)
                { 
                    SearchResult result = crawler.Search(item, distinctQueries[i]);
                    querySearch.Add(distinctQueries[i], result.Value);
                    Console.WriteLine("{0}:> {1}: {2}", distinctQueries[i],result.Engine,result.Value);
                }
                totals.Add(item.Name, querySearch);
            }

            ProcessResults(totals);
        }

        private static void ProcessResults(Dictionary<string, Dictionary<string, Int64>> totals)
        {
            List<ISearchEngine> engineList = GetEngines();
            Dictionary<string, string> finalResult = new Dictionary<string, string>();
            foreach (ISearchEngine item in engineList)
            {
                finalResult.Add(item.Name, "");
            }

            long globalTemp = 0;
            string totalWinner = String.Empty;
            foreach (string item in totals.Keys)
            {
                Dictionary<string, Int64> querySearch = totals[item];
                long temp = 0;
                foreach (string result in querySearch.Keys)
                {
                    if (querySearch[result] > temp)
                    {
                        temp = querySearch[result];
                        finalResult[item] = result;
                        if (querySearch[result] > globalTemp)
                        {
                            globalTemp = querySearch[result];
                            totalWinner = finalResult[item];
                        }
                    }
                }
            }

            foreach (string item in finalResult.Keys)
            {
                Console.WriteLine("{0} Winner: {1}", item, finalResult[item]);
            }
            Console.WriteLine("TOTAL Winner: {0}", totalWinner);
            
        }

        private static List<ISearchEngine> GetEngines()
        {
            List<ISearchEngine> engineList = new List<ISearchEngine>
            {
                new GoogleSearchEngine(),
                new MsnSearchEngine()
            };
            return engineList;
        }

    }
}
