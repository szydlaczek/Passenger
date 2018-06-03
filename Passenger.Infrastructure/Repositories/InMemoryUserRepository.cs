using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User Get(string email)
            => _users.Single(u => u.Email == email.ToLowerInvariant());

        public User Get(Guid id)
            => _users.Single(u => u.Id == id);

        public IEnumerable<User> GetAll()
            => _users;

        public void Remove(Guid id)
        {
            var user = Get(id);
            _users.Remove(user);
        }

        public void Update(User user)
        {
           
        }
    }
}
