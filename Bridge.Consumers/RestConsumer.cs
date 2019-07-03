using Bridge.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.Consumers
{
    [Route("consumer")]
    [ApiController]
    public class RestConsumer: ControllerBase
    {
        public string Id { get; set; }
        private readonly IProcessorCollection _processorCollection;
        private readonly IPassiveJobProcessor _processor;

        public RestConsumer(IProcessorCollection processorCollection)
        {
            _processorCollection = processorCollection;
            _processor = (IPassiveJobProcessor)_processorCollection?.GetProcessor("RestProcessor");
        }

        [HttpPost("")]
        public ActionResult PostMessage(string message)
        {
            _processor?.ProcessData(message);
            return Ok();
        }

        [HttpGet("")]
        public ActionResult<string> GetMessage()
        {
            return Ok("working");
        }
    }
}
