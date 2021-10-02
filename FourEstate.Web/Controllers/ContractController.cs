using FourEstate.Core.Constants;
using FourEstate.Core.Dtos;
using FourEstate.Infrastructure.Services.ContractServices;
using FourEstate.Infrastructure.Services.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourEstate.Web.Controllers
{
    public class ContractController : Controller
    {

        private readonly IContractService _contractService;
        private readonly ICustomerService _customerService;
        //private readonly IRealEstateService _realEstateService;

        public ContractController(IContractService contractService, ICustomerService customerService/*, IRealEstateService realEstateService*/)
        {
            _contractService = contractService;
            _customerService = customerService;
            //_realEstateService = realEstateService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetContractData(Pagination pagination,Query query)
        {
            var result = await _contractService.GetAll(pagination, query);
            return  Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["Customers"] = new SelectList(await _customerService.GetCustomerName(), "Id", "FullName");
        //    ViewData["realEstates"] = new SelectList(await _realEstateService.GetRelEstateName(), "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContractDto dto)
        {
            if (ModelState.IsValid)
            {
                await _contractService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }
            ViewData["Customers"] = new SelectList(await _customerService.GetCustomerName(), "Id", "FullName");
          //  ViewData["realEstates"] = new SelectList(await _realEstateService.GetRelEstateName(), "Id", "Name");
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var user = await _contractService.Get(id);
            ViewData["customers"] = new SelectList(await _customerService.GetCustomerName(), "Id", "FullName");
           // ViewData["realEstates"] = new SelectList(await _realEstateService.GetRelEstateName(), "Id", "FullName");
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateContractDto dto)
        {
            if (ModelState.IsValid)
            {
                await _contractService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            ViewData["customers"] = new SelectList(await _customerService.GetCustomerName(), "Id", "FullName");
          //  ViewData["realEstates"] = new SelectList(await _realEstateService.GetRelEstateName(), "Id", "FullName");
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _contractService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }

    }
}
