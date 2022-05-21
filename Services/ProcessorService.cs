using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using ImageProcessor.Models;

namespace ImageProcessor.Services
{
    public class ProcessorService
    {
        public ProcessorService()
        {

        }

        private OperatorModel picture;

        private Image image;

        public Image performFlip(string dir)
        {
            FlipMode direction = FlipMode.Vertical;

            if (dir.ToLower().StartsWith("h"))
                direction = FlipMode.Horizontal;

            image.Mutate(x => x
                    .Flip(direction));

            image.Save("output/fb.png"); // Automatic encoder selected based on extension.

            return image;
        }

    }
}
