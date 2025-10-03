using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatify.Core.Dtos;
using Chatify.Core.Dtos.AuthDtos;

namespace Chatify.Core.Services
{
    public interface IAuthService
    {
        Task<GeneralResponseDto<bool>> RegisterUser(RegisterDto registerDto);
        Task<GeneralResponseDto<string>> Login(LoginDto loginDto);
    }
}
