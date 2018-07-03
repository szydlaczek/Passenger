﻿using System;
using System.IO;
using System.Security.Cryptography;

using System.Collections.Generic;
using System.Text;
using Passenger.Infrastructure.Extensions;

namespace Passenger.Infrastructure.Services
{
    public class Encrypter : IEncrypter
    {
        private static readonly int DeriveBytesIterationsCount = 10000;
        private static readonly int SaltSize = 40;

        public string GetSalt(string value)
        {
            if (value.Empty())
            {
                throw new ArgumentException("Cannot generate salt from empty value");
            }
            var random = new Random();
            var saltBytes = new Byte[SaltSize];
            var rng = RandomNumberGenerator.Create();
            return Convert.ToBase64String(saltBytes);
        }


        public string GetHash(string value, string salt)
        {
            if (value.Empty())
                throw new ArgumentException("Cannot generate hash from empty value");
            if (salt.Empty())
                throw new ArgumentException("Cannot generate hash from empty salt");
            var pbkdf2 = new Rfc2898DeriveBytes(value, GetBytes(salt), DeriveBytesIterationsCount);
            return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));
        }

        private byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
        
    }
}
