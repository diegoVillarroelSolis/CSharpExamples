using ComplexJwtAuthentication.Auth;
using ComplexJwtAuthentication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplexJwtAuthentication.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IJwtHandler _jwtHandler;

        public UserService(IUserRepository repository,
            IJwtHandler jwtHandler)
        {
            _repository = repository;
            _jwtHandler = jwtHandler;
        }

        public async Task<JsonWebToken> LoginAsync(string name, string password)
        {
            var user = await _repository.GetAsync(name);
            if (user == null || !user.ValidatePassword(password))
            {
                return null;
            }
            return _jwtHandler.Create(user.Id);
        }
    }
}
