/*
 * Robert (Bob) Brown rbrown3
 * CPSC 5200-01-SQ22, Seattle University
 * This is free and unencumbered software release into the public domain.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using ImageProcessor.Models;

// AUTHOR:      Bob Brown rbrown3
// PROGRAM:     ImageProcessor API
// DATE:        2022-05-18

namespace ImageProcessor.Controllers
{
    /// <summary>
    /// The OperatorController class
    /// </summary>
    public class OperatorController
    {
        /// <summary>
        /// The OperatorController constructor
        /// </summary>
        public OperatorController()
        {

        }

        public OperatorController(OperatorModel picture)
        {
            image = picture;
        }

        // The OperatorModel image for the OperatorController object
        private OperatorModel image;

        private string parseCommand()
        {
            foreach (string operation in image.command)
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
                        convertGrayscale(image.image);
                        break;
                    
                    case "saturate":
                        saturate(image.image);
                        break;
                    
                    case "desatruate":
                        desaturate(image.image);
                        break;

                    case "resize":
                        break;

                }
            }

            return null;
        }

        public Image performFlip(string dir)
        {

            return null;
        }


        public Image rotate(int value, Image image)
        {
            return null;
        }

        public Image rotate(string direction, Image image)
        {
            return null;
        }

        public Image convertGrayscale(Image image)
        {
            return null;
        }

        public Image convertGrayscale(int value, Image image)
        {
            return null;
        }

        public Image saturate(Image image)
        {
            return null;
        }

        public Image desaturate(Image image)
        {
            return null;
        }

        public Image resize(float x, float y, Image image)
        {
            return null;
        }
    }

}
