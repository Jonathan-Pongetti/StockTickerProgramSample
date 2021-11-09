using System;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;

namespace WebAPIClient
{
    public class Ticker
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("from")]
        public string From{ get; set; }
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        
        [JsonPropertyName("open")]
        public float Open { get; set; }

        [JsonPropertyName("high")]
        public float High { get; set; }

        [JsonPropertyName("low")]
        public float Low { get; set; }
        [JsonPropertyName("close")]
        public float Close { get; set; }

        [JsonPropertyName("volume")]
        public int Volume { get; set; }
        [JsonPropertyName("afterhours")]
        public float Afterhours { get; set; }
        [JsonPropertyName("preMarket")]
        public float Premarket { get; set; }

        public string Name { get; set; }

        public string percentChange {get; set; }


        public Ticker(){}

        public void setName(string stockname){
          this.Name = stockname;
        }
        public void setPercentChange(){
            string arrow = "↑";
            var calc = (1.0f-(this.Open/this.Close))*100.0f; 
            if (calc < 0)
            {
                calc = calc*-1;
                arrow = "↓";
            }
            this.percentChange = calc.ToString($"{arrow} 0.##\\%");
        }

        public string returnString()
        {
            return this.Symbol + "   " + this.Name + "   Open: $" + this.Open + "   Close: $" + this.Close + "   Percent Change: " + percentChange;
        }

    }
}