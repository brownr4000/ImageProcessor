/*
 * Robert (Bob) Brown rbrown3
 * CPSC 5200-01-SQ22, Seattle University
 * This is free and unencumbered software release into the public domain.
 */

using ImageProcessor.Models;
using ImageProcessor.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

// AUTHOR:      Bob Brown rbrown3
// PROGRAM:     ImageProcessor API
// DATE:        2022-05-18

namespace ImageProcessor.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly ILogger<RequestController> _logger;

        // The OperatorModel image for the OperatorController object
        public ImageModel image = new ImageModel();

        private ProcessorService process;

        public RequestController(ILogger<RequestController> logger)
        {
            _logger = logger;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [ActionName("Get")]
        public string Get()
        {
            image.Command = new List<string> { "rotate 180" };

            process = new ProcessorService(image);

            //process.parseCommand();

            return image.Id;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public string Post([FromBody] string value)
        {
            List<string> requests = value.Split("; ").ToList();

            image.Command = requests;

            process = new ProcessorService(image);

            //process.parseCommand();

            return "output/" + image.Id + ".png";
        }

    }
}
