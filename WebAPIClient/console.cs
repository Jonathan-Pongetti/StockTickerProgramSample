using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Text;


namespace WebAPIClient
{
    public class ConsoleWriter
    {

        public ConsoleWriter(){}

        public void AnimateConsole(string stockInfo)
        {
            Console.Clear();
            int cursorCounter = 150;
            var printed = new StringBuilder();
    
            for(int i=0; i < 151; i++)
            {
                    if (i < stockInfo.Length)
                        printed.Append(stockInfo[i]);
                    else
                        printed.Append(" ");
    
                    Console.SetCursorPosition(cursorCounter, 0);
                    Console.Write(printed.ToString());
    
                    if (cursorCounter == 0)
                    {
                        return;
                    }
                    cursorCounter -= 1;
                    System.Threading.Thread.Sleep(70);
            }
        }

    }
}