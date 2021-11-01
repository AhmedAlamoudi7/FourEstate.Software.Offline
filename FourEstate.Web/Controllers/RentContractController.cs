using FourEstate.Core.Constants;
using FourEstate.Core.Dtos;
using FourEstate.Core.Enums;
using FourEstate.infrastructure.Services.ContractSS;
using FourEstate.infrastructure.Services.RentContracts;
using FourEstate.Infrastructure.Services.Customers;
using FourEstate.Infrastructure.Services.REAlEstate;
using FourEstate.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourEstate.Web.Controllers
{
    public class RentContractController : BaseController
    {
        private readonly IRentContractService _rentcontractService;
        private readonly ICustomerService _customerService;
        private readonly IRealEstateService _realEstateService;

        public RentContractController(IRentContractService rentcontractService, ICustomerService customerService, IRealEstateService realEstateService, IUserService userService) : base(userService)
        {
            _rentcontractService = rentcontractService;
            _customerService =     customerService;
            _realEstateService =   realEstateService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> GetLog(int Id)
        {
            var logs = await _rentcontractService.GetLog(Id);
            return View(logs);
        }




        public async Task<JsonResult> GetRentContractData(Pagination pagination, Query query)
        {
            var result = await _rentcontractService.GetAll(pagination, query);
            return Json(result);
        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {

            ViewData["customer"] = new SelectList(await _customerService.GetCustomerName(), "Id", "FullName");
            ViewData["realeste"] = new SelectList(await _realEstateService.GetRealEstateName(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRentContractDto dto)
        {
            if (ModelState.IsValid)
            {
                await _rentcontractService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }

            ViewData["customer"] = new SelectList(await _customerService.GetCustomerName(), "Id", "FullName");
            ViewData["realeste"] = new SelectList(await _realEstateService.GetRealEstateName(), "Id", "Name");

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewData["customer"] = new SelectList(await _customerService.GetCustomerName(), "Id", "FullName");
            ViewData["realeste"] = new SelectList(await _realEstateService.GetRealEstateName(), "Id", "Name");
            var rentcontract = await _rentcontractService.Get(id);
            return View(rentcontract);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateRentContractDto dto)
        {
            if (ModelState.IsValid)
            {
                await _rentcontractService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            ViewData["customer"] = new SelectList(await _customerService.GetCustomerName(), "Id", "FullName");
            ViewData["realeste"] = new SelectList(await _realEstateService.GetRealEstateName(), "Id", "Name");
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _rentcontractService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }


        [HttpGet]
        public async Task<IActionResult> UpdateStatus(int id, ContentStatus status)
        {
            await _rentcontractService.UpdateStatus(id, status);
            return Ok(Results.UpdateStatusResult());
        }

        [HttpGet]
        public async Task<IActionResult> ExportToExcel()
        {
            return File(await _rentcontractService.ExportToExcel(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "report_RentContract.xlsx");
        }
    }
}
