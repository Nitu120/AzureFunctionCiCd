using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using System.Collections.Generic;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats;


namespace AzureFunctionCiCd
{
    public static class Function1
    {
        [FunctionName("ResizeImage")]
        [StorageAccount("StorageConnString")]
        public static void Run([BlobTrigger("images/{name}")] Stream image,
        [Blob("thumbnails/{name}", FileAccess.Write)] Stream imageSmall)
        {
            IImageFormat format = Image.DetectFormat(image);



            using (Image<Rgba32> input = Image.Load<Rgba32>(image))
            {
                ResizeImage(input, imageSmall, ImageSize.Small, format);
            }
        }



        public static void ResizeImage(Image<Rgba32> input, Stream output, ImageSize size,
            IImageFormat format)
        {
            var dimensions = imageDimensionsTable[size];



            input.Mutate(x => x.Resize(dimensions.Item1, dimensions.Item2));
            input.Save(output, format);
        }



        public enum ImageSize { ExtraSmall, Small, Medium }



        private static Dictionary<ImageSize, (int, int)> imageDimensionsTable =
            new Dictionary<ImageSize, (int, int)>() {
                { ImageSize.ExtraSmall, (320, 200) },
                { ImageSize.Small,      (640, 400) },
                { ImageSize.Medium,     (800, 600) }
        };



    }
}
    

