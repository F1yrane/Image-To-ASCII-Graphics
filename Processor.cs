using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ImageToASCIIGraphics
{
    class Processor
    {
        public static async Task ProcessUserInput(string filePath, string apiKey, string query)
        {
            string apiUrl = $"https://pixabay.com/api/?key={apiKey}&q={query}&image_type=photo";

            using HttpClient? client = new();
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                dynamic data = JObject.Parse(json);

                if (data.total > 0)
                {
                    Random rnd = new();
                    int randomIndex = rnd.Next(0, data.hits.Count);
                    string imageUrl = data.hits[randomIndex].largeImageURL;

                    string imagePath = Path.Combine(filePath, "photo.jpg");
                    await DownloadImageAsync(imageUrl, imagePath);
                    Console.WriteLine("Image successfully downloaded.");

                    Art.Draw();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("No images found.");
                }
            }
            else
            {
                Console.WriteLine("Error: " + response.StatusCode);
            }
        }

        static async Task DownloadImageAsync(string url, string filePath)
        {
            using HttpClient? client = new();
            using HttpResponseMessage response = await client.GetAsync(url);
            using Stream streamToReadFrom = await response.Content.ReadAsStreamAsync();
            using Stream streamToWriteTo = File.Open(filePath, FileMode.Create);
            await streamToReadFrom.CopyToAsync(streamToWriteTo);

            await streamToWriteTo.FlushAsync();
            streamToWriteTo.Close();
            await streamToReadFrom.FlushAsync();
            streamToReadFrom.Close();
        }
    }
}
