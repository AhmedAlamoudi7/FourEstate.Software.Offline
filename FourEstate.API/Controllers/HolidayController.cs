
using FourEstate.Core.Constants;
using FourEstate.Core.Dtos;
using FourEstate.infrastructure.Services.Holidays;
using FourEstate.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourEstate.API.Controllers
{
    public class HolidayController : BaseController
    {
        private readonly IHolidayService _holidayService;

        public HolidayController(IHolidayService holidayService)/*, IUserService userService) : base(userService)*/
        {
            _holidayService = holidayService;
        }


        [HttpGet]
        public IActionResult GetAll(string searchKey)
        {
            var category = _holidayService.GetAllAPI(searchKey);
            return Ok(GetRespons(category, Results.GetSuccessResult()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateHolidayDto dto)
        {
            if (ModelState.IsValid)
            {
                await _holidayService.Create(dto);
                return Ok(GetRespons(Results.AddSuccessResult()));
            }
            return Ok(dto);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateHolidayDto dto)
        {
            if (ModelState.IsValid)
            {
                await _holidayService.Update(dto);
                return Ok(GetRespons(Results.EditSuccessResult()));
            }
            return Ok(dto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _holidayService.Delete(id);
            return Ok(GetRespons(Results.DeleteSuccessResult()));
        }

        //[HttpGet]
        //public async Task<IActionResult> ExportToExcel()
        //{
        //    //var r = File(await _categoryService.ExportToExcel(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "report_Category.xlsx");
        //    return Ok(GetRespons(""),r);
        //}
    }
}


