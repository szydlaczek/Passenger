using Passenger.Core.Domain;
using System;
using System.Collections.Generic;

namespace Passenger.Core.Repositories
{
    public interface IUserRepository
    {
        User Get(string email);

        User Get(Guid id);

        IEnumerable<User> GetAll();

        void Add(User user);

        void Update(User user);

        void Remove(Guid id);
    }
}