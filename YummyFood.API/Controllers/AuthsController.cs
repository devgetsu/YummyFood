using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YummyFood.API.Extensions;
using YummyFood.Application.Abstractions.AuthServices;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Entities.Auth;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly SignInManager<UserApp> _signInManager;
        private readonly IAuthService _authService;

        public AuthsController(UserManager<UserApp> userManager, SignInManager<UserApp> signInManager, IAuthService authService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }

            var newUser = new UserApp()
            {
                UserName = model.FullName.Split(" ")[0],
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,
                Role = "User"
                
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
                throw new Exception();

            await _userManager.AddToRoleAsync(newUser, "User");

            return Ok(new ResponseModel()
            {
                IsSuccess = true,
                Message = "Successfully created",
                StatusCode = 201
            });

        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }
            var user = await _userManager.FindByPhoneNumberAsync(model.PhoneNumber);

            if (user == null)
            {
                return BadRequest(new ResponseModel()
                {
                    Message = "User Not Found!",
                    StatusCode = 404
                });
            }

            var checker = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!checker)
            {
                return BadRequest(new ResponseModel()
                {
                    Message = "Password do not match!",
                    StatusCode = 401
                });
            }

            var token = _authService.GenerateToken(user);

            return Ok(new TokenDTO()
            {
                IsSuccess = true,
                Message = "Signed In Successfully",
                Token = token
            });

        }

        [HttpPost("ExternalLogin")]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLogin(ExternalLoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                user = new UserApp()
                {
                    UserName = model.FirstName + model.LastName,
                    FullName = model.FirstName + model.LastName,
                    Email = model.Email,
                    ProfilePhoto = model.PhotoUrl,
                    Role = "User"
                };

                await _userManager.CreateAsync(user);

                await _userManager.AddToRoleAsync(user, "User");
            }

            var info = new UserLoginInfo(model.Provider, model.ProviderKey, user.UserName);

            await _userManager.AddLoginAsync(user, info);

            await _signInManager.SignInAsync(user, false);

            var token = _authService.GenerateToken(user);

            return Ok(new TokenDTO()
            {
                IsSuccess = true,
                Message = "Successfully Signed In With External Login",
                Token = token
            });
        }
    }
}
