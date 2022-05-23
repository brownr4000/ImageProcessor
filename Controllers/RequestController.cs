﻿/*
 * Robert (Bob) Brown rbrown3
 * CPSC 5200-01-SQ22, Seattle University
 * This is free and unencumbered software release into the public domain.
 */

using ImageProcessor.Models;
using ImageProcessor.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        [ActionName("GetId")]
        public string GetId()
        {
            image.Command = new List<string> { "Convert" };

            process = new ProcessorService(image);

            process.parseCommand();

            return image.Id;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [ActionName("GetCommand")]
        public List<string> GetCommand()
        {
            return image.Command;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public List<string> Post([FromBody] string value)
        {
            List<string> requests = value.Split("; ").ToList();

            image.Command = requests;

            return image.Command;
        }

        // PUT api/<ValuesController>
        [HttpPut]
        public List<string> PutCommand([FromBody] string value)
        {
            List<string> requests = value.Split("; ").ToList();

            image.Command = requests;

            return image.Command;
        }

    }
}
