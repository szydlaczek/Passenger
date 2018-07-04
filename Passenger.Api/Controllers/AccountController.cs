﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    
    public class AccountController :  ApiControllerBase
    {

        private readonly IJwtHandler _jwtHandler;
        public AccountController(ICommandDispatcher commandDispatcher, IJwtHandler jwtHandler) 
            : base(commandDispatcher)
        {
            _jwtHandler = jwtHandler;
        }
        [HttpGet]
        [Route("token")]
        public async Task<IActionResult> Get()
        {

            var token=_jwtHandler.CreateToken("user1@email.com", "user");
            return Json(token);
        }
        //[HttpGet]
        //[Authorize]
        //[Route("auth")]
        //public async Task<IActionResult> GetAuth()
        //{

        //    return Content("Test");
        //}
        [HttpPut]
        [Route("Password")]
        public async Task<IActionResult> Put([FromBody]ChangeUserPassword command)
        {
            await CommandDispatcher.DispatchAsync(command);
            
            return NoContent();
        }
    }
}