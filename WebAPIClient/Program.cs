using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace WebAPIClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
           var index = new Random();
           string filePath = @"C:\Users\jpong\Documents\requestattempt\WebAPIClient\sym-name.csv";
           StockList StockList = new StockList(filePath);
           ConsoleWriter animator = new ConsoleWriter();


           while(true){

              var currIndex = index.Next(499);
              var symbol = StockList.getSymbol(currIndex);
              Ticker ticker = await ProcessTickerInfo(symbol);
              ticker.setName(StockList.getName(currIndex));
              ticker.setPercentChange();
              animator.AnimateConsole(ticker.returnString()); 

           }

        }
       private static async Task<Ticker> ProcessTickerInfo(string symbol)
        {
            client.DefaultRequestHeaders.Accept.Clear();

            var yesterday = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");

            var teststream = client.GetStreamAsync($"https://api.polygon.io/v1/open-close/{symbol}/{yesterday}?adjusted=true&apiKey=hkj9NrX__9Ig_cA7VP5pYnfNHAdrgaSF");

            Ticker ticker = await JsonSerializer.DeserializeAsync<Ticker>(await teststream);
            return ticker;

        }

    }
}
