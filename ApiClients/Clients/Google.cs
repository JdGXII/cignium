using ApiClients.Interfaces;
using Models.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

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
            foreach(string query in queries)
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
            var url = new StringBuilder(BaseUrl);
            url.Append($"&q={query}");
            url.Append($"&cx={CX}");
            url.Append($"&key={Key}");

            return url.ToString();
        }
    }
}
