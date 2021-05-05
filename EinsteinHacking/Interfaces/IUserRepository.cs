using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EinsteinHacking.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<IdentityUser> GetUserByID(int id);
        IEnumerable<IdentityUser> GetUserByEmail(string email);
        IEnumerable<IdentityUser> GetUserByUsername(string username);
    }
}
