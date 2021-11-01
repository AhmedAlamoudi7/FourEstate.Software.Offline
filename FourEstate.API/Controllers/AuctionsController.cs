using FourEstate.Core.Constants;
using FourEstate.Core.Dtos;
using FourEstate.Core.Enums;
using FourEstate.infrastructure.Services.Auctions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourEstate.API.Controllers
{
    public class AuctionsController : BaseController
    {
        
            private readonly IAuctionService _auctionService;

            public AuctionsController(IAuctionService auctionService)
            {
                _auctionService = auctionService;
            }


        [HttpGet]
        public async Task<IActionResult> GetLog(int Id)
        {
            var logs = await _auctionService.GetLog(Id);
            return Ok(GetRespons(logs, Results.GetSuccessResult()));
        }

        [HttpGet]
        public IActionResult GetAll(string serachKey)
        {
            var category = _auctionService.GetAllAPI(serachKey);
            return Ok(GetRespons(category, Results.GetSuccessResult()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateAuctionDto dto)
        {
            await _auctionService.Create(dto);
            return Ok(GetRespons(Results.AddSuccessResult()));
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateAuctionDto dto)
        {
            await _auctionService.Update(dto);
            return Ok(GetRespons(Results.EditSuccessResult()));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _auctionService.Delete(id);
            return Ok(GetRespons(Results.DeleteSuccessResult()));
        }


        [HttpGet]
        public async Task<IActionResult> UpdateStatus(int id, ContentStatus status)
        {
            await _auctionService.UpdateStatus(id, status);
            return Ok(GetRespons(Results.UpdateStatusResult()));
        }


        //[HttpGet]
        //public async Task<IActionResult> ExportToExcel()
        //{
        //    return File(await _realEstateService.ExportToExcel(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "report_RealEstate.xlsx");
        //}




        [HttpGet]
        public async Task<IActionResult> RemoveAttachment(int id)
        {
            await _auctionService.RemoveAttachment(id);
            return Ok(GetRespons(Results.DeleteSuccessResult()));
        }

    }
}
