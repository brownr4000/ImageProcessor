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
    /// <summary>
    /// The ProcessorService performs transformations and operations on an ImageModel
    /// object as part of the ImageProcessor application
    /// </summary>
    public class ProcessorService
    {

        /// <summary>
        /// The ProcessorService constructor takes in an ImageModel
        /// and starts processing its stored commands
        /// </summary>
        /// <param name="image">The ImageModel object to process</param>
        public ProcessorService(ImageModel image)
        {
            // Set picture to passed in image
            picture = image;

            negative = picture.Image;

            // Call parseCommand method
            parseCommand();
        }

        // ImageModel object to store ImageModel
        public ImageModel picture;

        // Image object to process image operations
        public Image negative;

        /// <summary>
        /// The SaveOutput method saves the output of the image manipulation
        /// 
        /// This could be modified to handle differnet filetypes
        /// </summary>
        private void SaveOutput()
        {
            // Call the SaveAsPng method of ImageSharp API
            negative.SaveAsPng("output/" + picture.Id + ".png");
        }

        /// <summary>
        /// The parseCommand method reads the Command list of the stored ImageModel
        /// and determines what operations to perform until the entire list has
        /// been traversed
        /// </summary>
        private void parseCommand()
        {
            // Loop through all elements of the List
            foreach (string operation in picture.Command)
            {
                // Separate strings based on empty spaces
                var action = operation.Split(" ");

                // Check which string is first in action
                switch (action.FirstOrDefault())
                {
                    // Flip operation
                    case "flip":
                        performFlip(action[1]);
                        break;

                    // Rotate operation
                    case "rotate":
                        rotate(action[1]);
                        break;

                    // Convert to Grayscale operation
                    case "convert":
                        pickGrayscale(action[1]);
                        break;

                    // Saturate operation
                    case "saturate":
                        saturate();
                        break;

                    // Desaturate operation
                    case "dull":
                        desaturate();
                        break;

                    // Resize operation
                    case "resize":
                        pickResize(action[1], action[2]);
                        break;

                    // Generate thumbnail opeation
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
        private void performFlip(string dir)
        {
            // FlipMode enum variable
            FlipMode direction;

            // Check the first character of the passed in string
            // to determine flip mode
            if (dir.ToLower().StartsWith("h"))
                direction = FlipMode.Horizontal;
            else
                direction = FlipMode.Vertical;

            // Perform flip operation
            negative.Mutate(x => x.Flip(direction));

            // Save image
            SaveOutput();
        }

        /// <summary>
        /// The rotate method rotates the image based on the passed in value
        /// </summary>
        /// <param name="value">The value to rotate</param>
        private void rotate(string value)
        {
            // Check if the string is a floating point number
            if (float.TryParse(value, out float number))
            {
                negative.Mutate(x => x.Rotate(number));
            }

            // Check if the lowercase of the string is ccw
            // Then perform rotate operation
            else if (value.ToLower() == "ccw")
                negative.Mutate(x => x.Rotate(RotateMode.Rotate270));

            else
                negative.Mutate(x => x.Rotate(RotateMode.Rotate90));

            // Save image
            SaveOutput();
        }

        /// <summary>
        /// The convertGrayscale method converts the image to grayscale
        /// </summary>
        private void convertGrayscale()
        {
            // Perform conversion to Grayscale
            negative.Mutate(x => x.Grayscale());

            // Save image
            SaveOutput();
        }

        /// <summary>
        /// The convertGrayscale method converts the image to grayscale based
        /// on the given floating point number
        /// </summary>
        /// <param name="value">The value of the grayscale to apply</param>
        /// <returns>The mutated image</returns>
        private void convertGrayscale(float value)
        {
            // Perform conversion to Grayscale with the passed in value
            negative.Mutate(x => x.Grayscale(value));

            // Save image
            SaveOutput();
        }

        /// <summary>
        /// The pickGrayscale determines which convertGrayscale method to call
        /// based on the passed in value
        /// </summary>
        /// <param name="value">The passed in string value</param>
        private void pickGrayscale(string value)
        {
            // Check if the passed in value is a floating point number
            if (float.TryParse(value, out float number))
                convertGrayscale(number);

            else
                convertGrayscale();
        }

        /// <summary>
        /// The saturate method applies saturation to the image
        /// </summary>
        private void saturate()
        {
            // Perform saturate operation
            negative.Mutate(x => x.Saturate(1.5f));

            // Save image
            SaveOutput();
        }

        /// <summary>
        /// The desaturate method removes saturation from the image
        /// </summary>
        private void desaturate()
        {
            //  Perform saturate operation with lower value
            // Effect dulls image by 50%
            negative.Mutate(x => x.Saturate(0.5f));

            // Save image
            SaveOutput();
        }

        /// <summary>
        /// The resize method changes the size of the image based on the
        /// given x and y values
        /// </summary>
        /// <param name="x">The width value to change</param>
        /// <param name="y">The height value to change</param>
        private void resize(int x, int y)
        {
            // Calculate x and y values to resize image
            // Add passed in values to the height and width
            int xValue = negative.Width + x;
            int yValue = negative.Height + y;

            // Perform resize operation
            negative.Mutate(x => x.Resize(xValue, yValue));

            // Save image
            SaveOutput();
        }

        /// <summary>
        /// The resize method changes the size of an image based on the
        /// given percent value
        /// </summary>
        /// <param name="percent"></param>
        private void resize(float percent)
        {
            // Calculate x and y values to resize image
            // Multiply height and width by passed in value
            var xValue = negative.Width * percent;
            var yValue = negative.Height * percent;

            // Perform resize operation
            negative.Mutate(x => x.Resize((int)xValue, (int)yValue));

            // Save image
            SaveOutput();
        }

        /// <summary>
        /// The pickRezise method determines which resize method to call
        /// based on the passed in values
        /// </summary>
        /// <param name="first">The first passed in string</param>
        /// <param name="second">The second passed in string</param>
        private void pickResize(string first, string second)
        {
            // Check if the passed in value is a floating point number
            if (float.TryParse(first, out float num))
            {
                // Check if the second passed in value is an integer
                if (int.TryParse(second, out int y))
                    resize((int) num, y);

                else
                    resize(num);
            }
        }

        /// <summary>
        /// The generateThumb method generates a low quality thumbnail for the image
        /// It utilizes the resize functionality of the image library
        /// </summary>
        private void generateThumb()
        {
            // Reduce height and width values
            int xValue = negative.Width  / 2;
            var yValue = negative.Height / 2;

            // Perform resize operation
            negative.Mutate(x => x.Resize(xValue, yValue, KnownResamplers.NearestNeighbor));

            // Save image
            SaveOutput();
        }
    }
}
