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

        /// <summary>
        /// The rotate method rotates the image based on a direction string
        /// </summary>
        /// <param name="dir">The direction to rotate, assuming CW or CCW</param>
        /// <returns>The mutated image</returns>
        public Image rotate(string dir)
        {
            RotateMode tap = RotateMode.Rotate90;

            if (dir.ToLower() == "ccw")
                tap = RotateMode.Rotate270;

            image.Mutate(x => x.Rotate(tap));

            image.Save("output/fb.png"); // Automatic encoder selected based on extension.

            return image;
        }

        /// <summary>
        /// The convertGrayscale method converts the image to grayscale
        /// </summary>
        /// <returns>The mutated image</returns>
        public Image convertGrayscale()
        {
            image.Mutate(x => x.Grayscale());

            image.Save("output/fb.png"); // Automatic encoder selected based on extension.

            return image;
        }

        /// <summary>
        /// The convertGrayscale method converts the image to grayscale based
        /// on the given floating point number
        /// </summary>
        /// <param name="value">The value of the grayscale to apply</param>
        /// <returns>The mutated image</returns>
        public Image convertGrayscale(float value)
        {
            image.Mutate(x => x.Grayscale(value));

            image.Save("output/fb.png"); // Automatic encoder selected based on extension.

            return image;
        }

        /// <summary>
        /// The saturate method applies saturation to the image
        /// </summary>
        public void saturate()
        {
            image.Mutate(x => x.Saturate(0.5f));
        }

        /// <summary>
        /// The desaturate method removes saturation from the image
        /// </summary>
        public void desaturate()
        {
            image.Mutate(x => x.Saturate(0));
        }

        /// <summary>
        /// The resize method changes the size of the image based on the
        /// given x and y values
        /// </summary>
        /// <param name="x">The width value to change</param>
        /// <param name="y">The height value to change</param>
        public void resize(int x, int y)
        {
            int xValue = image.Width + x;
            int yValue = image.Height + y;

            image.Mutate(x => x.Resize(xValue, yValue));
        }

        /// <summary>
        /// The resize method changes the size of an image based on the
        /// given percent value
        /// </summary>
        /// <param name="percent"></param>
        public void resize(float percent)
        {
            var xValue = image.Width * percent;
            var yValue = image.Height * percent;

            image.Mutate(x => x.Resize((int)xValue, (int)yValue));
        }

        /// <summary>
        /// The generateThumb method generates a low quality thumbnail for the image
        /// </summary>
        public void generateThumb()
        {
            int xValue = image.Width  / 2;
            var yValue = image.Height / 2;

            image.Mutate(x => x.Resize(xValue, yValue, KnownResamplers.NearestNeighbor));
        }


    }
}
