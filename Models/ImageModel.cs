/*
 * Robert (Bob) Brown rbrown3
 * CPSC 5200-01-SQ22, Seattle University
 * This is free and unencumbered software release into the public domain.
 */

using System.Collections.Generic;
using SixLabors.ImageSharp;

// AUTHOR:      Bob Brown rbrown3
// PROGRAM:     ImageProcessor API
// DATE:        2022-05-18
//

namespace ImageProcessor.Models
{
    /// <summary>
    /// The OperatorModel class defines an OperatorModel object that stores and Image
    /// and a list of commands
    /// </summary>
    public class ImageModel
    {
        public ImageModel()
        {
            Image = Image.Load("input/test_image.png");
        }

        public ImageModel(List<string> commands)
        {
            Command = commands;

            Image = Image.Load("input/test_image.png");

        }

        /// <summary>
        /// The OperatorModel constructor stores an image and a list of strings
        /// </summary>
        /// <param name="picture">An Image to perform operations on</param>
        /// <param name="process">A list of strings of operations to perform</param>
        public ImageModel(Image picture, List<string> commands)
        {
            Command = commands;

            Image = picture;

        }

        public string Id { get; set; } = System.Guid.NewGuid().ToString();

        /// <summary>
        /// The list of strings to hold the image manipulation commands
        /// </summary>
        public List<string> Command { get; set; } = new List<string>{ "empty commands", "empty commands" };

        /// <summary>
        /// The Image to be manipulated
        /// </summary>
        public Image Image { get; set; }

    }
}
