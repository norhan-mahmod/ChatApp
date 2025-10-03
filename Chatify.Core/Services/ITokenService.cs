using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatify.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Chatify.Core.Services
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(ApplicationUser user, UserManager<ApplicationUser> userManager);
    }
}
