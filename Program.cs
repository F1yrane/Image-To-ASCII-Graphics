using System;
using System.Threading.Tasks;

namespace ImageToASCIIGraphics
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string filePath = @"F:\Dev\ImageToASCIIGraphics\ContentDownload\";
            string apiKey = "38519273-51bb27659ca29f833b32894f5";
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




