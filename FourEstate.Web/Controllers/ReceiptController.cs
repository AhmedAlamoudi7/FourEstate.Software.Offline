using FourEstate.Core.Constants;
using FourEstate.Core.Dtos;
using FourEstate.infrastructure.Services.Receipts;
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
    public class ReceiptController : BaseController
    {
        private readonly IReceiptService _ReceiptService;
        private readonly IRentContractService _RentContractService;
        private readonly ICustomerService _CustomerService;
        private readonly IRealEstateService _RealEstateService;

        public ReceiptController(IReceiptService ReceiptService, IRealEstateService RealEstateService, ICustomerService CustomerService, IRentContractService RentContractService, IUserService userService) : base(userService)
        {
            _ReceiptService = ReceiptService;
            _RentContractService = RentContractService;
            _CustomerService = CustomerService;
            _RealEstateService = RealEstateService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetReceiptData(Pagination pagination, Query query)
        {
            var result = await _ReceiptService.GetAll(pagination, query);
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["realEstate"] = new SelectList(await _RealEstateService.GetRealEstateName(), "Id", "Name");
            ViewData["user"] = new SelectList(await _userService.GetUserFullName(), "Id", "FullName");
            ViewData["customer"] = new SelectList(await _CustomerService.GetCustomerName(), "Id", "FullName");
            ViewData["rentContract"] = new SelectList(await _RentContractService.GetRentContractName(), "Id", "NumberOfContract");


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReceiptDto dto)
        {
            if (ModelState.IsValid)
            {
                await _ReceiptService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }

            ViewData["realEstate"] = new SelectList(await _RealEstateService.GetRealEstateName(), "Id", "Name");
            ViewData["user"] = new SelectList(await _userService.GetUserFullName(), "Id", "FullName");
            ViewData["customer"] = new SelectList(await _CustomerService.GetCustomerName(), "Id", "FullName");
            ViewData["rentContract"] = new SelectList(await _RentContractService.GetRentContractName(), "Id", "NumberOfContract");

            return View(dto);
        }



        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewData["realEstate"] = new SelectList(await _RealEstateService.GetRealEstateName(), "Id", "Name");
            ViewData["user"] = new SelectList(await _userService.GetUserFullName(), "Id", "FullName");
            ViewData["customer"] = new SelectList(await _CustomerService.GetCustomerName(), "Id", "FullName");
            ViewData["rentContract"] = new SelectList(await _RentContractService.GetRentContractName(), "Id", "NumberOfContract");
            var receipt = await _ReceiptService.Get(id);
            return View(receipt);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateReceiptDto dto)
        {
            if (ModelState.IsValid)
            {
                await _ReceiptService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            ViewData["realEstate"] = new SelectList(await _RealEstateService.GetRealEstateName(), "Id", "Name");
            ViewData["user"] = new SelectList(await _userService.GetUserFullName(), "Id", "FullName");
            ViewData["customer"] = new SelectList(await _CustomerService.GetCustomerName(), "Id", "FullName");
            ViewData["rentContract"] = new SelectList(await _RentContractService.GetRentContractName(), "Id", "NumberOfContract");
            return View(dto);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _ReceiptService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }




        [HttpGet]
        public async Task<IActionResult> ExportToExcel()
        {
            return File(await _ReceiptService.ExportToExcel(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "report_Receipt.xlsx");
        }





    }
}
