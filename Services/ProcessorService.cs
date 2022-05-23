/*
 * Robert (Bob) Brown rbrown3
 * CPSC 5200-01-SQ22, Seattle University
 * This is free and unencumbered software release into the public domain.
 */

using System.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using ImageProcessor.Models;

// AUTHOR:      Bob Brown rbrown3
// PROGRAM:     ImageProcessor API
// DATE:        2022-05-18

namespace ImageProcessor.Services
{
    public class ProcessorService
    {
        public ProcessorService()
        {

        }

        public ProcessorService(ImageModel image)
        {
            picture = image;

            negative = picture.Image;

            parseCommand();

        }

        private ImageModel picture;

        private Image negative;

        private void SaveOutput()
        {
            negative.SaveAsPng("output/" + picture.Id + ".png");
        }

        public void parseCommand()
        {
            foreach (string operation in picture.Command)
            {
                var action = operation.Split(" ");

                switch (action.FirstOrDefault())
                {
                    case "flip":
                        performFlip(action[1]);
                        break;

                    case "rotate":
                        rotate(action[1]);
                        break;

                    case "convert":
                        pickGrayscale(action[1]);
                        break;

                    case "saturate":
                        saturate();
                        break;

                    case "desatruate":
                        desaturate();
                        break;

                    case "resize":
                        pickResize(action[1], action[2]);
                        break;

                    case "thumb":
                        generateThumb();
                        break;

                }
            }
        }

        /// <summary>
        /// The performFlip method flips the image horizontally or vertically
        /// based on the string directon
        /// </summary>
        /// <param name="dir">The direction to flip the image</param>
        public void performFlip(string dir)
        {
            FlipMode direction;

            if (dir.ToLower().StartsWith("h"))
                direction = FlipMode.Horizontal;
            else
                direction = FlipMode.Vertical;

            negative.Mutate(x => x.Flip(direction));

            SaveOutput();
        }

        /// <summary>
        /// The rotate method rotates the image based on the passed in value
        /// </summary>
        /// <param name="value">The value to rotate</param>
        public void rotate(string value)
        {
            // Check if the string is a floating point number
            if (float.TryParse(value, out float number))
            {
                negative.Mutate(x => x.Rotate(number));
            }

            // Check if the lowercase of the string is ccw
            else if (value.ToLower() == "ccw")
                negative.Mutate(x => x.Rotate(RotateMode.Rotate270));

            else
                negative.Mutate(x => x.Rotate(RotateMode.Rotate90));


            SaveOutput();
        }

        /// <summary>
        /// The convertGrayscale method converts the image to grayscale
        /// </summary>
        public void convertGrayscale()
        {
            negative.Mutate(x => x.Grayscale());

            SaveOutput();
        }

        /// <summary>
        /// The convertGrayscale method converts the image to grayscale based
        /// on the given floating point number
        /// </summary>
        /// <param name="value">The value of the grayscale to apply</param>
        /// <returns>The mutated image</returns>
        public void convertGrayscale(float value)
        {
            negative.Mutate(x => x.Grayscale(value));

            SaveOutput();
        }

        /// <summary>
        /// The pickGrayscale determines which convertGrayscale method to call
        /// based on the passed in value
        /// </summary>
        /// <param name="value">The passed in string value</param>
        public void pickGrayscale(string value)
        {
            if (float.TryParse(value, out float number))
                convertGrayscale(number);

            else
                convertGrayscale();
        }

        /// <summary>
        /// The saturate method applies saturation to the image
        /// </summary>
        public void saturate()
        {
            negative.Mutate(x => x.Saturate(1.5f));

            SaveOutput();
        }

        /// <summary>
        /// The desaturate method removes saturation from the image
        /// </summary>
        public void desaturate()
        {
            negative.Mutate(x => x.Saturate(0.5f));

            SaveOutput();
        }

        /// <summary>
        /// The resize method changes the size of the image based on the
        /// given x and y values
        /// </summary>
        /// <param name="x">The width value to change</param>
        /// <param name="y">The height value to change</param>
        public void resize(int x, int y)
        {
            int xValue = negative.Width + x;
            int yValue = negative.Height + y;

            negative.Mutate(x => x.Resize(xValue, yValue));

            SaveOutput();
        }

        /// <summary>
        /// The resize method changes the size of an image based on the
        /// given percent value
        /// </summary>
        /// <param name="percent"></param>
        public void resize(float percent)
        {
            var xValue = negative.Width * percent;
            var yValue = negative.Height * percent;

            negative.Mutate(x => x.Resize((int)xValue, (int)yValue));

            SaveOutput();
        }

        public void pickResize(string first, string second)
        {
            if (float.TryParse(first, out float num))
            {
                if (int.TryParse(second, out int y))
                    resize((int) num, y);

                else
                    resize(num);
            }
        }

        /// <summary>
        /// The generateThumb method generates a low quality thumbnail for the image
        /// </summary>
        public void generateThumb()
        {
            int xValue = negative.Width  / 2;
            var yValue = negative.Height / 2;

            negative.Mutate(x => x.Resize(xValue, yValue, KnownResamplers.NearestNeighbor));

            SaveOutput();
        }
    }
}
