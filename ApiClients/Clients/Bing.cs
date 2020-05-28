using ApiClients.Interfaces;
using Models.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.WebUtilities;
using ErrorHandling.Exceptions;

namespace ApiClients.Clients 
{
    public class Bing : IBingClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string BaseUrl { get; set; }
        private string Key { get; set; }
        private string OcpApimSubscriptionHeaderName { get; set; }

        public Bing(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;

            var clientConfigurationSection = configuration.GetSection("BingClient");
            BaseUrl = clientConfigurationSection.GetSection("BaseUrl").Value.ToString();
            Key = clientConfigurationSection.GetSection("Key").Value.ToString();
            OcpApimSubscriptionHeaderName = clientConfigurationSection.GetSection("OcpApimSubscriptionHeaderName").Value.ToString();

            _httpClient.DefaultRequestHeaders.Add(OcpApimSubscriptionHeaderName, Key);
        }

        public async Task<List<BingResponse>> GetResults(List<string> queries)
        {
            if (queries.Count == 0 || queries.Contains(string.Empty) || queries.Contains(" ")) throw new EmptyQueryException();

            List<BingResponse> responses = new List<BingResponse>();
            foreach (string query in queries)
            {
                string url = BuildFullUrl(query);                
                var responseString = await _httpClient.GetStringAsync(url);
                var response = await Task.Run(() => JsonConvert.DeserializeObject<BingResponse>(responseString));
                responses.Add(response);
            }

            return responses;
        }

        private string BuildFullUrl(string query)
        {
            var queryParameters = new Dictionary<string, string>();
            queryParameters.Add("q", query);

            return QueryHelpers.AddQueryString(BaseUrl, queryParameters);
        }
    }
}
