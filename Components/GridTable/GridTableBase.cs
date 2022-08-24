using Microsoft.AspNetCore.Components;
using TestBlazor.Shared.Models;

namespace TestBlazor.Components.GridTable
{
    public class GridTableBase: ComponentBase
    {
        //Parameter to pass
        [Parameter]
        public IList<CryptocurrencyListing> Items { get; set; }
    }
}
