using Microsoft.AspNetCore.Components;
using TestBlazor.Client.Services;

namespace TestBlazor.Client.Pages
{
    public class CryptoListBase : ComponentBase
    {
        //Injecting services
        [Inject]
        protected ICryptocurrencyListingService cryptocurrencyListingService { get; set; }

        //Executed when the component is completely loaded.
        protected override async Task OnInitializedAsync()
        {
            await cryptocurrencyListingService.GetCryptoList();
        }
        protected async void RefreshList()
        {
            await cryptocurrencyListingService.GetCryptoList();
        }
    }
}