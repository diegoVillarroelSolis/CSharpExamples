using ComplexJwtAuthentication.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplexJwtAuthentication.Services
{
    public interface IUserService
    {
        Task<JsonWebToken> LoginAsync(string name, string password);
    }
}
