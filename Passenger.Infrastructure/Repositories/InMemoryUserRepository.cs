﻿using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>
        {
            new User("user1@email.com", "secret", "salt", "user1"),
            new User("user2@email.com", "secret", "salt", "user2"),
            new User("user3@email.com", "secret", "salt", "user3")
        };

        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task<User> GetAsync(string email)
            => await Task.FromResult(_users.SingleOrDefault(u => u.Email == email.ToLowerInvariant()));

        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_users.Single(u => u.Id == id));

        public async Task<IEnumerable<User>> GetAllAsync()
            => await Task.FromResult(_users);

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            _users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
    }
}
