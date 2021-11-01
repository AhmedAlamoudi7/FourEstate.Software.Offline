using FourEstate.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourEstate.Web.Controllers
{
    public class FinanceController : BaseController
    {
        public FinanceController(IUserService userService) : base(userService)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
