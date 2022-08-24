namespace TestBlazor.Shared.Models
{
    public class CryptocurrencyListing
    {
        public string? Name { get; set; }
        public DateTime LastUpdated { get; set; }

        public int TotalSupply { get; set; }
        public int MaxSupply { get; set; }

        public string? Symbol { get; set; }

        public double? USD { get; set; }
    }
}