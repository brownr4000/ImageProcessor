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
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly ILogger<RequestController> _logger;

        // The OperatorModel image for the OperatorController object
        private ImageModel image;

        private ProcessorService process;

        public RequestController(ILogger<RequestController> logger)
        {
            _logger = logger;
        }

        public RequestController(ImageModel picture)
        {
            process = new ProcessorService();

            image = picture;

        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
