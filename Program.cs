using System;
using System.Threading.Tasks;

namespace ImageToASCIIGraphics
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string filePath = @"<PATH TO>ImageToASCIIGraphics\ContentDownload\";
            string apiKey = "<YOUR API KEY>";
            string? query;

            do
            {
                Console.Write("Enter a description of the photo ('exit' to close a program):  ");
                query = Console.ReadLine();

                if (!string.IsNullOrEmpty(query))
                {   
                    await Processor.ProcessUserInput(filePath, apiKey, query);
                }

            } while (query != "exit");
        }
    }
}




