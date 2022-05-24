/*
 * Robert (Bob) Brown rbrown3
 * CPSC 5200-01-SQ22, Seattle University
 * This is free and unencumbered software release into the public domain.
 */

using ImageProcessor.Models;
using ImageProcessor.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// AUTHOR:      Bob Brown rbrown3
// PROGRAM:     ImageProcessor API
// DATE:        2022-05-18

namespace ImageProcessor.Controllers
{
    /// <summary>
    /// The RequestController class provides the api/controller functionality
    /// for the ImageProcessor application
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        // The ImageModel image object stores the image and commands to be processed
        public ImageModel image = new ImageModel();

        // The ProcessorService process is the object to handle the image processing
        private ProcessorService process;

        /// <summary>
        /// The RequestController constructor
        /// </summary>
        public RequestController()
        {

        }

        /// <summary>
        /// The Get method verifies the server is operating by 
        /// returning a message to the client
        /// </summary>
        /// <returns>A string message to the client</returns>
        // GET: api/<ValuesController>
        [HttpGet]
        [ActionName("Get")]
        public string Get()
        {
            return "ready for images";
        }

        /// <summary>
        /// The Post method builds the command list from the body of the request
        /// applies it to the ImageModel object, and sends it to the ProcessorService.
        /// </summary>
        /// <param name="value">The string of commands entered by the client</param>
        /// <returns>The string of the location of the file on the server</returns>
        // POST api/<ValuesController>
        [HttpPost]
        [ActionName("Post")]
        public string Post([FromBody] string value)
        {
            // Build command list from string value
            List<string> requests = value.Split("; ").ToList();

            // Set object Command to created list
            image.Command = requests;

            // Activate ProcessorService
            process = new ProcessorService(image);

            // Return string of file location
            return "output/" + image.Id + ".png";
        }

    }
}
