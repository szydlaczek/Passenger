using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Services;
using System.Threading.Tasks;

namespace Passenger.Api.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/values/5
        [HttpGet("{email}")]
        public async Task<UserDto> Get(string email)
         => await _userService.GetAsync(email);

        [HttpPost("")]
        public async Task Post([FromBody]CreateUser request)
        => await _userService.RegisterAsync(request.Email, request.UserName, request.Password);
        
    }
}