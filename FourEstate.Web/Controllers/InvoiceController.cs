using FourEstate.Core.Constants;
using FourEstate.Core.Dtos;
using FourEstate.infrastructure.Services.Invoices;
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
    public class InvoiceController : BaseController
    {
        private readonly IInvoiceServices _IInvoiceServices;
        private readonly ICustomerService _ICustomerService;
        private readonly IRealEstateService _IRealEstateService;

        public InvoiceController(IInvoiceServices IInvoiceServices, ICustomerService ICustomerService, IRealEstateService IRealEstateService,IUserService userService) : base(userService)
        {
            _IInvoiceServices = IInvoiceServices;
            _ICustomerService = ICustomerService;
            _IRealEstateService = IRealEstateService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetInvoiceData(Pagination pagination, Query query)
        {
            var result = await _IInvoiceServices.GetAll(pagination, query);
            return Json(result);
        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["realEstate"] = new SelectList(await _IRealEstateService.GetRealEstateName(), "Id", "Name");
            ViewData["user"] = new SelectList(await _userService.GetUserFullName(), "Id", "FullName");
            ViewData["customer"] = new SelectList(await _ICustomerService.GetCustomerName(), "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInvoiceDto dto)
        {
            if (ModelState.IsValid)
            {
                await _IInvoiceServices.Create(dto);
                return Ok(Results.AddSuccessResult());
            }

            ViewData["realEstate"] = new SelectList(await _IRealEstateService.GetRealEstateName(), "Id", "Name");
            ViewData["user"] = new SelectList(await _userService.GetUserFullName(), "Id", "FullName");
            ViewData["customer"] = new SelectList(await _ICustomerService.GetCustomerName(), "Id", "FullName");
            return View(dto);
        }



        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewData["realEstate"] = new SelectList(await _IRealEstateService.GetRealEstateName(), "Id", "Name");
            ViewData["user"] = new SelectList(await _userService.GetUserFullName(), "Id", "FullName");
            ViewData["customer"] = new SelectList(await _ICustomerService.GetCustomerName(), "Id", "FullName");
            var invoice = await _IInvoiceServices.Get(id);
            return View(invoice);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateInvoiceDto dto)
        {
            if (ModelState.IsValid)
            {
                await _IInvoiceServices.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            ViewData["realEstate"] = new SelectList(await _IRealEstateService.GetRealEstateName(), "Id", "Name");
            ViewData["user"] = new SelectList(await _userService.GetUserFullName(), "Id", "FullName");
            ViewData["customer"] = new SelectList(await _ICustomerService.GetCustomerName(), "Id", "FullName");
            return View(dto);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _IInvoiceServices.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }




        [HttpGet]
        public async Task<IActionResult> ExportToExcel()
        {
            return File(await _IInvoiceServices.ExportToExcel(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "report_Invoice.xlsx");
        }










    }
}
