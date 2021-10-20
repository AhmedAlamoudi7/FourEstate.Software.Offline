using FourEstate.Core.Constants;
using FourEstate.Core.Dtos;
using FourEstate.Core.Enums;
using FourEstate.Infrastructure.Services.Auctions;
using FourEstate.Infrastructure.Services.Categories;
using FourEstate.Infrastructure.Services.LocationsService;
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
    public class AuctionController : BaseController
    {
        private readonly IAuctionService _auctionService;
        private readonly IRealEstateService _realEstateService;

        public AuctionController(IAuctionService auctionService,IRealEstateService realEstateService, IUserService userService) : base(userService)
        {
            _auctionService = auctionService;
            _realEstateService = realEstateService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }



        public async Task<IActionResult> GetLog(int Id)
        {
            var logs = await _auctionService.GetLog(Id);
            return View(logs);
        }



        public async Task<JsonResult> GetAuctionData(Pagination pagination, Query query)
        {
            var result = await _auctionService.GetAll(pagination, query);
            return Json(result);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["realEstate"] = new SelectList(await _realEstateService.GetRealEstateName(), "Id", "Name");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateAuctionDto dto)
        {

            if (ModelState.IsValid)
            {
                ViewData["realEstate"] = new SelectList(await _realEstateService.GetRealEstateName(), "Id", "Name");
                await _auctionService.Create(dto);
                return Ok(Results.AddSuccessResult());
             
            }
           
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewData["realEstate"] = new SelectList(await _realEstateService.GetRealEstateName(), "Id", "Name");
            var auction = await _auctionService.Get(id);
            return View(auction);
         
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateAuctionDto dto)
        {
            if (ModelState.IsValid)
            {
                ViewData["realEstate"] = new SelectList(await _realEstateService.GetRealEstateName(), "Id", "Name");
                await _auctionService.Update(dto);
                return Ok(Results.EditSuccessResult());
    
            }
     
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _auctionService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }


        [HttpGet]
        public async Task<IActionResult> UpdateStatus(int id, ContentStatus status)
        {
            await _auctionService.UpdateStatus(id, status);
            return Ok(Results.UpdateStatusResult());
        }


        [HttpGet]
        public async Task<IActionResult> ExportToExcel()
        {
            return File(await _auctionService.ExportToExcel(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "report_Auction.xlsx");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveAttachment(int id)
        {
            await _auctionService.RemoveAttachment(id);
            return Ok(Results.DeleteSuccessResult());
        }

    }
}
