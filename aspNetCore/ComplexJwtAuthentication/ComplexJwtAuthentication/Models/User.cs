﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplexJwtAuthentication.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public User()
        {
        }

        public User(string name, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Password = password;
        }

        internal bool ValidatePassword(string password)
        {
            return true;
        }
    }
}
