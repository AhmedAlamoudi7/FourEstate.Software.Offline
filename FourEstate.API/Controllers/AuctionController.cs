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

namespace FourEstate.API.Controllers
{
    public class AuctionController : BaseController
    {
        private readonly IAuctionService _auctionService;
        private readonly IRealEstateService _realEstateService;

        public AuctionController(IAuctionService auctionService,IRealEstateService realEstateService)/*, IUserService userService) : base(userService)*/
        {
            _auctionService = auctionService;
            _realEstateService = realEstateService;
        }

        [HttpGet]
        public IActionResult GetAll(string searchKey)
        {
            var auction = _auctionService.GetAllAPI(searchKey);
            return Ok(GetRespons(auction, Results.GetSuccessResult()));
        }


        [HttpGet]
        public async Task<IActionResult> GetLog([FromForm] int Id)
        {
            var logs = await _auctionService.GetLog(Id);
            return Ok(GetRespons(logs, Results.GetSuccessResult()));
        }




        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateAuctionDto dto)
        {

            if (ModelState.IsValid)
            {
                ViewData["realEstate"] = new SelectList(await _realEstateService.GetRealEstateName(), "Id", "Name");
                await _auctionService.Create(dto);
                return Ok(GetRespons(Results.AddSuccessResult()));

            }

            return Ok(dto);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromForm]UpdateAuctionDto dto)
        {
            if (ModelState.IsValid)
            {
                ViewData["realEstate"] = new SelectList(await _realEstateService.GetRealEstateName(), "Id", "Name");
                await _auctionService.Update(dto);
                return Ok(GetRespons(Results.EditSuccessResult()));
            }

            return Ok(dto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            await _auctionService.Delete(id);
            return Ok(GetRespons(Results.DeleteSuccessResult()));   
        
        }


        [HttpGet]
        public async Task<IActionResult> UpdateStatus([FromForm] int id, ContentStatus status)
        {
            await _auctionService.UpdateStatus(id, status);
            return Ok(GetRespons(Results.UpdateStatusResult()));     
        }


        //[HttpGet]
        //public async Task<IActionResult> ExportToExcel()
        //{
        //    return File(await _auctionService.ExportToExcel(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "report_Auction.xlsx");
        //}




        [HttpGet]
        public async Task<IActionResult> RemoveAttachment([FromForm] int id)
        {
            await _auctionService.RemoveAttachment(id);
            return Ok(GetRespons(Results.DeleteSuccessResult()));    
        }

    }
}
