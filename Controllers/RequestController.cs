/*
 * Robert (Bob) Brown rbrown3
 * CPSC 5200-01-SQ22, Seattle University
 * This is free and unencumbered software release into the public domain.
 */

using ImageProcessor.Models;
using ImageProcessor.Services;
using Microsoft.AspNetCore.Mvc;
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
        public RequestController()
        {

        }

        public RequestController(OperatorModel picture)
        {
            process = new ProcessorService();

            image = picture;

            parseCommand();
        }

        // The OperatorModel image for the OperatorController object
        private OperatorModel image;

        private ProcessorService process;

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
            return process.performFlip(dir);
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
