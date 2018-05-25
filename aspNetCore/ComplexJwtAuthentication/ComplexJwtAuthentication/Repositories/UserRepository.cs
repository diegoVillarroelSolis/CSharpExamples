using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComplexJwtAuthentication.Models;

namespace ComplexJwtAuthentication.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IProviderDatabe _database;
        public UserRepository(IProviderDatabe database)
        {
            _database = database;
        }

        public Task<User> GetAsync(string name)
        {
            return Task.FromResult(new User("user", "secret"));
        }
    }
}
