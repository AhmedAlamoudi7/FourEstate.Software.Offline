using FourEstate.Core.Constants;
using FourEstate.Core.Dtos;
using FourEstate.infrastructure.Services.CatchReceipts;
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
    public class CatchReceiptController : BaseController
    {
        private readonly ICatchReceiptService _CatchReceiptService;
        private readonly IRentContractService _RentContractService;
        private readonly ICustomerService _CustomerService;
        private readonly IRealEstateService _RealEstateService;

        public CatchReceiptController(ICatchReceiptService CatchReceiptService, IRealEstateService RealEstateService, ICustomerService CustomerService, IRentContractService RentContractService, IUserService userService) : base(userService)
        {
            _CatchReceiptService = CatchReceiptService;
            _RentContractService = RentContractService;
            _CustomerService = CustomerService;
            _RealEstateService = RealEstateService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetCatchReceiptData(Pagination pagination, Query query)
        {
            var result = await _CatchReceiptService.GetAll(pagination, query);
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
        public async Task<IActionResult> Create(CreateCatchReceiptDto dto)
        {
            if (ModelState.IsValid)
            {
                await _CatchReceiptService.Create(dto);
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
            var catchreceipt = await _CatchReceiptService.Get(id);
            return View(catchreceipt);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCatchReceiptDto dto)
        {
            if (ModelState.IsValid)
            {
                await _CatchReceiptService.Update(dto);
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
            await _CatchReceiptService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }




        [HttpGet]
        public async Task<IActionResult> ExportToExcel()
        {
            return File(await _CatchReceiptService.ExportToExcel(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "report_CatchReceipt.xlsx");
        }





    }
}
