/*
 * Robert (Bob) Brown rbrown3
 * CPSC 5200-01-SQ22, Seattle University
 * This is free and unencumbered software release into the public domain.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageProcessor.Services;
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
        /// <summary>
        /// The OperatorModel constructor stores an image and a list of strings
        /// </summary>
        /// <param name="picture">An Image to perform operations on</param>
        /// <param name="process">A list of strings of operations to perform</param>
        public ImageModel(Image picture, List<string> commands)
        {
            Command = commands;

            Image = picture;

            process = new ProcessorService();
        }

        private ProcessorService process;

        public string Id { get; set; } = System.Guid.NewGuid().ToString();

        /// <summary>
        /// The list of strings to hold the image manipulation commands
        /// </summary>
        public List<string> Command { get; set; }

        /// <summary>
        /// The Image to be manipulated
        /// </summary>
        public Image Image { get; set; }

    }
}
