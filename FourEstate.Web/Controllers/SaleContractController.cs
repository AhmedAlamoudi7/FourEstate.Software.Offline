using FourEstate.Core.Constants;
using FourEstate.Core.Dtos;
using FourEstate.Core.Enums;
using FourEstate.infrastructure.Services.ContractSS;
using FourEstate.infrastructure.Services.SaleContracts;
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
    public class SaleContractController : BaseController
    {
        private readonly ISaleContractService _salecontractService;
        private readonly ICustomerService _customerService;
        private readonly IRealEstateService _realEstateService;

        public SaleContractController(ISaleContractService salecontractService, ICustomerService customerService, IRealEstateService realEstateService, IUserService userService) : base(userService)
        {
            _salecontractService = salecontractService;
            _customerService = customerService;
            _realEstateService = realEstateService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> GetLog(int Id)
        {
            var logs = await _salecontractService.GetLog(Id);
            return View(logs);
        }




        public async Task<JsonResult> GetSaleContractData(Pagination pagination, Query query)
        {
            var result = await _salecontractService.GetAll(pagination, query);
            return Json(result);
        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["user"] = new SelectList(await _userService.GetUserFullName(), "Id", "FullName");
            ViewData["customer"] = new SelectList(await _customerService.GetCustomerName(), "Id", "FullName");
            ViewData["realeste"] = new SelectList(await _realEstateService.GetRealEstateName(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSaleContractDto dto)
        {
            if (ModelState.IsValid)
            {
                await _salecontractService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }

            ViewData["customer"] = new SelectList(await _customerService.GetCustomerName(), "Id", "FullName");
            ViewData["realeste"] = new SelectList(await _realEstateService.GetRealEstateName(), "Id", "Name");
            ViewData["user"] =     new SelectList(await _userService.GetUserFullName(), "Id", "FullName");

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewData["customer"] = new SelectList(await _customerService.GetCustomerName(), "Id", "FullName");
            ViewData["realeste"] = new SelectList(await _realEstateService.GetRealEstateName(), "Id", "Name");
            ViewData["user"] = new SelectList(await _userService.GetUserFullName(), "Id", "FullName");
            var contract = await _salecontractService.Get(id);
            return View(contract);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSaleContractDto dto)
        {
            if (ModelState.IsValid)
            {
                await _salecontractService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            ViewData["user"] = new SelectList(await _userService.GetUserFullName(), "Id", "FullName");
            ViewData["customer"] = new SelectList(await _customerService.GetCustomerName(), "Id", "FullName");
            ViewData["realeste"] = new SelectList(await _realEstateService.GetRealEstateName(), "Id", "Name");
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _salecontractService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }


        [HttpGet]
        public async Task<IActionResult> UpdateStatus(int id, ContentStatus status)
        {
            await _salecontractService.UpdateStatus(id, status);
            return Ok(Results.UpdateStatusResult());
        }

        [HttpGet]
        public async Task<IActionResult> ExportToExcel()
        {
            return File(await _salecontractService.ExportToExcel(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "report_SaleContract.xlsx");
        }
    }
}
