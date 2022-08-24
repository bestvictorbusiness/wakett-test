using TestBlazor.Shared.Models;

namespace TestBlazor.Client.Services
{
    public interface ICryptocurrencyListingService
    {
        List<CryptocurrencyListing> CryptoList { get; set; }
        Task GetCryptoList();
    }
}
