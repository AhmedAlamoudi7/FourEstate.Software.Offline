
using FourEstate.Core.Dtos.LoginDto;
using FourEstate.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FourEstate.Infrastructure.Services.AuthService
{
    public interface IAuthService
    {
        Task<LoginResponseViewModel> Login(LoginDto dto);

        Task<bool> ChangePassword(string userId, ChangePasswordDto dto);
    }
}
