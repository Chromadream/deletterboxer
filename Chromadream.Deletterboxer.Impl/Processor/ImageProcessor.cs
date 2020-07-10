using System;
using System.IO;
using SkiaSharp;

namespace Chromadream.Deletterboxer.Impl.Processor
{
    public static class ImageProcessor
    {
        public static int GetLetterboxHeight(string filePath) 
        {
            using (Stream stream = File.OpenRead(filePath))
            {
                return GetLetterboxHeight(stream);
            }
        }

        public static int GetLetterboxHeight(Stream file)
        {
            SKBitmap bitmap = SKBitmap.Decode(file);
            var centerWidth = bitmap.Width/2;
            var zeroPoint = bitmap.GetPixel(centerWidth, 0);
            SKColor somePoint;
            for (int i = 1; i < bitmap.Height; i++)
            {
                somePoint = bitmap.GetPixel(centerWidth, i);
                if (somePoint != zeroPoint)
                {
                    return i;
                }
            }
            throw new Exception();
        }
    }
}