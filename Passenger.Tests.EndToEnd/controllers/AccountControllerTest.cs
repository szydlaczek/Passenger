﻿using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Passenger.Api;
using Passenger.Infrastructure.Commands.Users;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Passenger.Tests.EndToEnd.controllers
{
    public class AccountControllerTest : ControllerBaseTests
    {
        
        public AccountControllerTest():base()
        {
            
        }
        [Fact]
        public async Task given_valid_current_and_new_password_it_should_be_changed()
        {
            var command = new ChangeUserPassword
            {
                CurrentPassword = "secret",
                NewPassword = "secret2"
            };
            var payload = GetPayload(command);
            var response =await Client.PutAsync("account/password", payload);
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NoContent); 
        }
    }
}
