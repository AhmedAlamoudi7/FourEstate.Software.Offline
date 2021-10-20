using FourEstate.Core.Constants;
using FourEstate.Core.Dtos.LoginDto;
using FourEstate.Infrastructure.Services.AuthService;
using FourEstate.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourEstate.API.Controllers
{
    public class AuthController : BaseController
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)/*,IUserService userService) : base(userService)*/
        {
            _authService = authService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromForm]LoginDto dto)
        {
           var result = await  _authService.Login(dto);
           return Ok((GetRespons(result, Results.GetSuccessResult())));
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromForm] ChangePasswordDto dto)
        {
            var result = await _authService.ChangePassword(UserId,dto);
            return Ok((GetRespons(result, Results.GetSuccessResult())));
        }

    }
}
