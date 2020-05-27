using ApiClients.Interfaces;
using Models.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiClients.Clients
{
    public class Google : IGoogleClient
    {
        private readonly HttpClient _httpClient;
        public string BaseUrl { get; set; }
        public string Key { get; set; }
        public string CX { get; set; }

        public Google(HttpClient httpClient)
        {
            _httpClient = httpClient;
            Key = "AIzaSyB7n9vpBj0pF0t0XBc_QRFJ7rcGSXCk5Lc";
            CX = "013337687656984343162:m1opahpzwmn";
            BaseUrl = $"https://customsearch.googleapis.com/customsearch/v1?q=java&fields=queries(request(totalResults))&key={Key}&cx={CX}";
        }

        public async Task<GoogleResponse> GetResults()
        {
            var responsestring = await _httpClient.GetStringAsync(BaseUrl);
            var response = await Task.Run(() => JsonConvert.DeserializeObject<GoogleResponse>(responsestring)); 

            return response;
        }       
    }
}
