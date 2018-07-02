﻿using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Handlers.NewFolder.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;
        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(CreateUser Command)
        {
            await _userService.RegisterAsync(Command.Email, Command.UserName, Command.Password);
        }
    }
}
