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

// AUTHOR:      Bob Brown rbrown3
// PROGRAM:     ImageProcessor API
// DATE:        2022-05-18
// PURPOSE:     
// INPUT:       
// PROCESS:     
// OUTPUT:      
//

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

        private string parseCommand()
        {
            return null;
        }

        public Image performHorizFlip(Image image)
        {
            return null;
        }

        public Image performVertFlip(Image image)
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
