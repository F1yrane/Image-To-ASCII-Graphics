#if NETCOREAPP
// Используйте System.Drawing только на Windows
using System.Drawing;
#endif

namespace ImageToASCIIGraphics
{
    public class Art
    {
        public static void Draw()
        {
            Bitmap image = new(@"F:\Dev\ImageToASCIIGraphics\ContentDownload\photo.jpg");

            int width = image.Width;
            int height = image.Height;

            int asciiWidth = 900;
            int asciiHeight = (int)(asciiWidth * (double)height / width);

            for (int y = 0; y < asciiHeight; y += 6) 
            {
                for (int x = 0; x < asciiWidth; x += 3)
                {
                    int originalX = (int)(x * (double)width / asciiWidth);
                    int originalY = (int)(y * (double)height / asciiHeight);

                    Color pixelColor = image.GetPixel(originalX, originalY);

                    int brightness = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);

                    char asciiChar = GetAsciiChar(brightness);

                    Console.Write(asciiChar);
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }

        static char GetAsciiChar(int brightness)
        {
            char[] asciiChars = { ' ', '.', ':', '-', '=', '+', '*', '#', '%', '8', '@' };

            int index = brightness * (asciiChars.Length - 1) / 255;

            return asciiChars[index];
        }
    }
}
