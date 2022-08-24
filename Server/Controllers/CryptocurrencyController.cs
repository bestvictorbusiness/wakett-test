using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TestBlazor.Shared.Models;

namespace TestBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptocurrencyController : ControllerBase
    {
        private readonly CoinMarketConfig _coinMarketConfig;

        public CryptocurrencyController(IOptions<CoinMarketConfig> coinmarketConfig)
        {
            _coinMarketConfig = coinmarketConfig.Value;
        }

        /// <summary>
        /// Gets cryptocurrency listing from a remote API
        /// </summary>
        /// <returns>List of Information of Cryptocurrencies</returns>
        [HttpGet("listing")]
        public async Task<ActionResult<List<CryptocurrencyListing>>> GetListing()
        {
            List<CryptocurrencyListing> list = new List<CryptocurrencyListing>();
            using (var httpClient = new HttpClient())
            {
                //Getting data from third-party API
                httpClient.DefaultRequestHeaders.Add("Accepts", "application/json");
                httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", _coinMarketConfig.API_KEY);
                using (var response = await httpClient.GetAsync("https://sandbox-api.coinmarketcap.com/v1/cryptocurrency/listings/latest"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    //Populating data to ApiResponse model.
                    var responseData = JsonConvert.DeserializeObject<ApiResponse>(apiResponse);

                    if (responseData != null)
                    {

                        for (int i = 0; i < responseData.Data.Length; i++)
                        {
                            var listItem = new CryptocurrencyListing()
                            {
                                LastUpdated = responseData.Data[i].last_updated,
                                Name = responseData.Data[i].name,
                                Symbol = responseData.Data[i].symbol,
                                MaxSupply = responseData.Data[i].max_supply,
                                TotalSupply = responseData.Data[i].total_supply,
                                USD = responseData.Data[i].quote.USD.price,
                            };

                            list.Add(listItem);
                        }
                    }
                    

                }
            }
            return Ok(list);
        }


    }
}
