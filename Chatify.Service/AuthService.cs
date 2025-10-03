using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatify.Core.Dtos;
using Chatify.Core.Dtos.AuthDtos;
using Chatify.Core.Entities;
using Chatify.Core.Services;
using Chatify.Service.Helper;
using Microsoft.AspNetCore.Identity;

namespace Chatify.Service
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ITokenService tokenService;

        public AuthService(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager,
                            ITokenService tokenService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
        }

        public async Task<GeneralResponseDto<bool>> RegisterUser(RegisterDto registerDto)
        {
            try
            {
                var isEmailExist = await userManager.FindByEmailAsync(registerDto.Email);
                if (isEmailExist is not null)
                    return new GeneralResponseDto<bool>()
                    {
                        IsSucceeded = false,
                        Message = "This Email is Already Exist!",
                        Data = false
                    };

                var user = new ApplicationUser()
                {
                    Email = registerDto.Email,
                    DisplayName = registerDto.DisplayName,
                    UserName = registerDto.DisplayName
                };

                // Upload Profile Picture
                if (registerDto.ProfilePicture is not null)
                    user.ProfilePictureURL = await DocumentSetting.UploadFile(registerDto.ProfilePicture, "ProfilePictures") ?? "";
                else
                    user.ProfilePictureURL = "/ProfilePictures/default.jpg";

                    var result = await userManager.CreateAsync(user,registerDto.Password);
                if (result.Succeeded)
                    return new GeneralResponseDto<bool>()
                    {
                        IsSucceeded = true,
                        Message = "User Registered Successfully!",
                        Data = true
                    };
                return new GeneralResponseDto<bool>()
                {
                    IsSucceeded = false,
                    Data = false,
                    Errors = result.Errors.Select(e => e.Description).ToList()
                };
            }
            catch(Exception ex)
            {
                return new GeneralResponseDto<bool>() { IsSucceeded = false , Message = ex.Message};
            }
        }


        public async Task<GeneralResponseDto<string>> Login(LoginDto loginDto)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(loginDto.Email);
                if (user is null)
                    return new GeneralResponseDto<string>()
                    {
                        IsSucceeded = false,
                        Message = "Unauthorized!"
                    };
                var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
                if(!result.Succeeded)
                    return new GeneralResponseDto<string>()
                    {
                        IsSucceeded = false,
                        Message = "Unauthorized!"
                    };
                // Generate Token
                var token = await tokenService.CreateTokenAsync(user,userManager);
                return new GeneralResponseDto<string>()
                {
                    IsSucceeded = true,
                    Message = "User Logged In Successfully!",
                    Data = token
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto<string>() { IsSucceeded = false , Message = ex.Message };
            }
        }
    }
}
