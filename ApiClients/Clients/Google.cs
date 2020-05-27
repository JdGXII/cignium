using ApiClients.Interfaces;
using Models.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.WebUtilities;

namespace ApiClients.Clients
{
    public class Google : IGoogleClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string BaseUrl { get; set; }
        private string Key { get; set; }
        private string CX { get; set; }

        public Google(HttpClient httpClient, IConfiguration configuration)
        {            
            _httpClient = httpClient;
            _configuration = configuration;
            var clientConfigurationSection = configuration.GetSection("GoogleClient");

            BaseUrl = clientConfigurationSection.GetSection("BaseUrl").Value.ToString();
            Key = clientConfigurationSection.GetSection("Key").Value.ToString();
            CX = clientConfigurationSection.GetSection("CX").Value.ToString();
        }

        public async Task<List<GoogleResponse>> GetResults(List<string> queries)
        {
            List<GoogleResponse> responses = new List<GoogleResponse>();            
            foreach (string query in queries)
            {
                string url = BuildFullUrl(query);
                var responseString = await _httpClient.GetStringAsync(url);
                var response = await Task.Run(() => JsonConvert.DeserializeObject<GoogleResponse>(responseString));
                responses.Add(response);
            }  

            return responses;
        } 
        
        private string BuildFullUrl(string query)
        {
            var queryParameters = new Dictionary<string, string>();
            queryParameters.Add("cx", CX);
            queryParameters.Add("key", Key);
            queryParameters.Add("q", query);

            return QueryHelpers.AddQueryString(BaseUrl, queryParameters);
        }
    }
}
