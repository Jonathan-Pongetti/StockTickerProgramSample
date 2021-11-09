using System.Collections.Generic;
using System.IO;

namespace WebAPIClient
{
    public class StockList
    {
        private List<string> symbolList = new List<string>();
        private List<string> nameList = new List<string>();

        public StockList(string path)
        {
            using(var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    symbolList.Add(values[0]);
                    nameList.Add(values[1]);

                }
            } 
        } 

        public string getSymbol(int index)
        {
            return symbolList[index];
        }  
        public string getName(int index)
        {
            return nameList[index];
        }
    }
}
