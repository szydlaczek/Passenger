using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Passenger.Api;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft;
using Newtonsoft.Json;
using Passenger.Infrastructure.DTO;
using FluentAssertions;
using System.Net;
using Passenger.Infrastructure.Commands.Users;

namespace Passenger.Tests.EndToEnd.controllers
{
    public class UserControllerTest : ControllerBaseTests
    {
        
        
        [Fact]
        public async Task given_valid_email_user_should_exist()
        {
            var email = "user1@email.com";
            var user = await GetUserAsync(email);  
            user.Email.Should().BeEquivalentTo(email);
        }
        [Fact]
        public async Task given_valid_email_user_should_not_exist()
        {
            var email = "user100@email.com";
            var response = await Client.GetAsync($"users/{email}");
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
            

        }

        
        [Fact]
        public async Task given_unique_email_user_should_be_created()
        {
           
                var command = new CreateUser
                {
                    Email = "test@email.com",
                    UserName = "test",
                    Password = "secret"

                };
            var payload = GetPayload(command);
            var response = await Client.PostAsync("users", payload);
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().Should().BeEquivalentTo($"users/{command.Email}");

            var user = await GetUserAsync(command.Email);
            user.Email.Should().BeEquivalentTo(command.Email);
        }
       
        private async Task<UserDto> GetUserAsync(string email)
        {
            var response = await Client.GetAsync($"users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }
    }
}
