
using Microsoft.Extensions.Configuration;
using ServiceContracts.Interfaces;
using System.Net.Http;
using System.Text.Json;


namespace Services
{
    public class FinnhubService : IFinnhubService
    {

     

        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _configuration;
        public FinnhubService(IHttpClientFactory httpClient, IConfiguration confi)
        {
            _httpClient = httpClient;
            _configuration = confi;
        }



        public async Task<Dictionary<string, object>?> GetCompanyProfile(string StockSymbol)
        {
           using(HttpClient httpClient = _httpClient.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/stock/profile2?symbol={StockSymbol}&token={_configuration["GetCompanyToken"]}"),
                    Method = HttpMethod.Get,
                };


                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                Stream stream = httpResponseMessage.Content.ReadAsStream();
                StreamReader streamReader = new StreamReader(stream);

                string response = streamReader.ReadToEnd();

                Dictionary<string, object> responseDictionary = 
                    JsonSerializer.Deserialize<Dictionary<string, object>>(response);

                if (responseDictionary is null) { throw new InvalidOperationException("No response from Finnhub Service"); }
                if (responseDictionary.ContainsKey("error")) { throw new InvalidOperationException(Convert.ToString(responseDictionary["error"])); }

                return responseDictionary;
            }
        }

        public async Task<Dictionary<string, object>?> GetStockPriceQuote(string StockSymbol)
        {
            using (HttpClient httpClient = _httpClient.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={StockSymbol}&token={_configuration["GetStockToken"]}"),
                    Method = HttpMethod.Get
                };
                HttpResponseMessage httpResponseMessage =
                    await httpClient.SendAsync(httpRequestMessage);

                Stream stream = httpResponseMessage.Content.ReadAsStream();
                StreamReader streamReader = new StreamReader(stream);

                string response = streamReader.ReadToEnd();

                Dictionary<string,object> responseDictionary =
                    JsonSerializer.Deserialize<Dictionary<string, object>>(response);

                if (responseDictionary is null) { throw new InvalidOperationException("No Respone from Finnhub"); }
                if (responseDictionary.ContainsKey("error")) { throw new InvalidOperationException(Convert.ToString(responseDictionary["error"])); }

                return responseDictionary;


            }
        }
    }
}
