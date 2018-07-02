using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;

namespace Passenger.Api.Controllers
{
    
    public class DriverController : ApiControllerBase
    {
        public DriverController(ICommandDispatcher dispatcher)
            : base(dispatcher)
        {
        }
        [HttpPost]
        public Task<IActionResult> Put([FromBody]CreateDriver command)
        {

        }
    }
}