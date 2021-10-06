using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourEstate.Web.Controllers
{

    [Authorize]
    public class BaseController : Controller
    {
        ////public IActionResult Index()
        ////{
        ////    return View();
        ////}
    }
}


//protected readonly IUserService _userService;
//protected string userType;

//public BaseController(IUserService userService)
//{
//    _userService = userService;
//}