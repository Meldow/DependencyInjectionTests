using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace GetServicesByInterface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IServices services;

        public ValuesController(IServices services)
        {
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            this.services.Execute();

            return new[] { "Hello" };
        }
    }
}