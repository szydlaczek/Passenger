using System;
using System.Text.RegularExpressions;

namespace Passenger.Core.Domain
{
    public class User
    {
        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string UserName { get; protected set; }
        public string FullName { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected User()
        {
        }

        public User(string email, string password, string salt, string username)
        {
            Id = Guid.NewGuid();
            Email = email.ToLowerInvariant();
            Password = password;
            Salt = salt;
            UserName = username;
            CreatedAt = DateTime.UtcNow;
        }
        public void SetUsername(string username)
        {
            if (!NameRegex.IsMatch(username))
            {
                
            }

            if (String.IsNullOrEmpty(username))
            {
                
            }

            UserName = username.ToLowerInvariant();
            
        }
    }
}