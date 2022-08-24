using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBlazor.Shared.Models
{
    //Model designed based on third-party api response
    public class ApiResponse
    {
        public object Status { get; set; }
        public Data[] Data { get; set; }
    }

    public class Data
    {
        public string name { get; set; }
        public string symbol { get; set; }
        public int total_supply { get; set; }
        public int max_supply { get; set; }
        public DateTime last_updated { get; set; }
        public Quote quote { get; set; }
    }

    public class Quote
    {
        public USD USD { get; set; }
        public BTC BTC { get; set; }
    }

    public class USD
    {
        public double price { get; set; }
    }

    public class BTC
    {
        public double price { get; set; }
    }

}
