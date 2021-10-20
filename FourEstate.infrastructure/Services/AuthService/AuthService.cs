
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FourEstate.Data;
using FourEstate.Data.Models;
using FourEstate.Core.ViewModel;
using FourEstate.Core.Dtos.LoginDto;
using FourEstate.Core.Exceptions;
using FourEstate.Core.ViewModels;

namespace FourEstate.Infrastructure.Services.AuthService
{
    public class AuthService : IAuthService
    {

        private readonly FourEstateDbContext _DB;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration,RoleManager<IdentityRole> roleManager, FourEstateDbContext DB, IMapper mapper, UserManager<User> userManager)
        {
            _DB = DB;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }


        public async Task<LoginResponseViewModel> Login(LoginDto dto)
        {
            var user = _DB.Users.SingleOrDefault(x => x.UserName == dto.Username && !x.IsDelete);

            if(user == null)
            {
                throw new InvalidUsernameOrPasswordException();
            }

            var result = await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!result)
            {
                throw new InvalidUsernameOrPasswordException();
            }

            if (!user.IsActive)
            {
                throw new UserNotActiveExceptionException();
            }

            var accessToken = await GenrateAccessToken(user);
            var userVm = _mapper.Map<UserViewModel>(user);

            return new LoginResponseViewModel()
            {
                AccessToken = accessToken,
                User = userVm
            };
        }


        public async Task<bool> ChangePassword(string userId,ChangePasswordDto dto)
        {
            var user = _DB.Users.Find(userId);
            var result = await _userManager.ChangePasswordAsync(user, dto.OldPassword, dto.NewPassword);
            return result.Succeeded;
        }





        private async Task<string> GenrateAccessToken(User user)
        {

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>(){
              new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
              new Claim(JwtRegisteredClaimNames.Email, user.Email),
              new Claim("UserId",user.Id),
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };
            
            if (roles.Any())
            {
                claims.Add(new Claim(ClaimTypes.Role, string.Join(",", roles)));
            }


            var expires = DateTime.Now.AddMonths(1);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Signinkey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var accessToken = new JwtSecurityToken(_configuration["Jwt:Issure"],
                _configuration["Jwt:Site"],
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(accessToken);
        }



    }
}
