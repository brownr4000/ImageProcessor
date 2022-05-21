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

        /// <summary>
        /// The performFlip method flips the image horizontally or vertically
        /// based on the string directon
        /// </summary>
        /// <param name="dir">The direction to flip the image</param>
        /// <returns>The mutated image</returns>
        public Image performFlip(string dir)
        {
            FlipMode direction = FlipMode.Vertical;

            if (dir.ToLower().StartsWith("h"))
                direction = FlipMode.Horizontal;

            image.Mutate(x => x.Flip(direction));

            image.Save("output/fb.png"); // Automatic encoder selected based on extension.

            return image;
        }

        /// <summary>
        /// The rotate method rotates the image based on a value in degrees
        /// </summary>
        /// <param name="value">A floating point value</param>
        /// <returns>The mutated image</returns>
        public Image rotate(float value)
        {
            image.Mutate(x => x.Rotate(value));

            image.Save("output/fb.png"); // Automatic encoder selected based on extension.

            return image;
        }

        public Image rotate(string dir)
        {
            RotateMode tap = RotateMode.Rotate90;

            if (dir.ToLower() == "ccw")
                tap = RotateMode.Rotate270;

            image.Mutate(x => x.Rotate(tap));

            image.Save("output/fb.png"); // Automatic encoder selected based on extension.

            return image;
        }

        public Image convertGrayscale()
        {
            image.Mutate(x => x.Grayscale());

            image.Save("output/fb.png"); // Automatic encoder selected based on extension.

            return image;
        }

        public Image convertGrayscale(float thing)
        {
            image.Mutate(x => x.Grayscale(thing));

            image.Save("output/fb.png"); // Automatic encoder selected based on extension.

            return image;
        }

    }
}
