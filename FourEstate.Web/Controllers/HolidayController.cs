
using FourEstate.Core.Constants;
using FourEstate.Core.Dtos;
using FourEstate.infrastructure.Services.Holidays;
using FourEstate.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourEstate.Web.Controllers
{
    public class HolidayController : BaseController
    {
        private readonly IHolidayService _holidayService;

        public HolidayController(IHolidayService holidayService, IUserService userService) : base(userService)
        {
            _holidayService = holidayService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetHolidayData(Pagination pagination, Query query)
        {
            var result = await _holidayService.GetAll(pagination, query);
            return Json(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateHolidayDto dto)
        {
            if (ModelState.IsValid)
            {
                await _holidayService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var user = await _holidayService.Get(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateHolidayDto dto)
        {
            if (ModelState.IsValid)
            {
                await _holidayService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _holidayService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }

        [HttpGet]
        public async Task<IActionResult> ExportToExcel()
        {
            return File(await _holidayService.ExportToExcel(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "report_Holiday.xlsx");
        }
    }
}
