using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using TestBlazor.Shared.Models;

namespace TestBlazor.Client.Services
{
    public class CryptocurrencyListingService : ICryptocurrencyListingService
    {
        //Injecting dependencies
        private readonly HttpClient _http;
        public CryptocurrencyListingService(HttpClient http)
        {
            _http = http;
        }

        public List<CryptocurrencyListing> CryptoList { get; set; } = new List<CryptocurrencyListing>();

        //Populating CryptoList from Api
        public async Task GetCryptoList()
        {
            var result = await _http.GetFromJsonAsync<List<CryptocurrencyListing>>("api/cryptocurrency/listing");
            if (result != null)
                CryptoList = result;
        }
    }
}
