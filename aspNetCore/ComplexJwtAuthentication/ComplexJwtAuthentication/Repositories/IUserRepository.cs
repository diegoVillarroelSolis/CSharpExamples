using ComplexJwtAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplexJwtAuthentication.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(string name);
    }
}
