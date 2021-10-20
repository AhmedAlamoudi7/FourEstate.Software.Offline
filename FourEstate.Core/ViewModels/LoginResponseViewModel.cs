using FourEstate.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourEstate.Core.ViewModel
{
    public class LoginResponseViewModel
    {
        public string AccessToken { get; set; }
        public UserViewModel User { get; set; }

    }
}
