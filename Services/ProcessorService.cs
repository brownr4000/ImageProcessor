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
            negative.SaveAsJpeg("output/" + picture.Id + ".jpg");
        }

        private string parseCommand()
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
                        break;

                    case "convert":
                        convertGrayscale();
                        break;

                    case "saturate":
                        //saturate(image.image);
                        break;

                    case "desatruate":
                        //desaturate(image.image);
                        break;

                    case "resize":
                        break;

                }
            }

            return null;
        }


        /// <summary>
        /// The performFlip method flips the image horizontally or vertically
        /// based on the string directon
        /// </summary>
        /// <param name="dir">The direction to flip the image</param>
        public void performFlip(string dir)
        {
            FlipMode direction = FlipMode.Vertical;

            if (dir.ToLower().StartsWith("h"))
                direction = FlipMode.Horizontal;

            negative.Mutate(x => x.Flip(direction));

            SaveOutput();
        }

        /// <summary>
        /// The rotate method rotates the image based on a value in degrees
        /// </summary>
        /// <param name="value">A floating point value</param>
        public void rotate(string value)
        {
           
            if (float.TryParse(value, out float number))
            {
                negative.Mutate(x => x.Rotate(number));
            }
            else if (value.ToLower() == "ccw")
                negative.Mutate(x => x.Rotate(RotateMode.Rotate90));
            else
                

            if (value.ToLower() == "ccw")
                negative.Mutate(x => x.Rotate(RotateMode.Rotate270));

            SaveOutput();
        }

        /// <summary>
        /// The rotate method rotates the image based on a value in degrees
        /// </summary>
        /// <param name="value">A floating point value</param>
        public void rotate(float value)
        {
            negative.Mutate(x => x.Rotate(value));

            SaveOutput();
        }

        /// <summary>
        /// The rotate method rotates the image based on a direction string
        /// </summary>
        /// <param name="dir">The direction to rotate, assuming CW or CCW</param>
        public void rotate(string dir)
        {
            RotateMode tap = RotateMode.Rotate90;

            if (dir.ToLower() == "ccw")
                tap = RotateMode.Rotate270;

            negative.Mutate(x => x.Rotate(tap));

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
        /// The saturate method applies saturation to the image
        /// </summary>
        public void saturate()
        {
            negative.Mutate(x => x.Saturate(0.5f));

            SaveOutput();
        }

        /// <summary>
        /// The desaturate method removes saturation from the image
        /// </summary>
        public void desaturate()
        {
            negative.Mutate(x => x.Saturate(0));

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
