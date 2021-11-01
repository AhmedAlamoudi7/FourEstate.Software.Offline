using FourEstate.Core.Constants;
using FourEstate.Core.Dtos;
using FourEstate.Core.Enums;
using FourEstate.infrastructure.Services.Auctions;
using FourEstate.Infrastructure.Services.REAlEstate;
using FourEstate.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace FourEstate.Web.Controllers
{
    public class AuctionsController : BaseController
    {
        private readonly IAuctionService _auctionService;
        private readonly IRealEstateService _realEstateService;

        public AuctionsController(IAuctionService auctionService, IRealEstateService realEstateService, IUserService userService) : base(userService)
        {
            _auctionService = auctionService;
            _realEstateService = realEstateService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetAuctionsData(Pagination pagination, Query query)
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
                await _auctionService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }

            ViewData["realEstate"] = new SelectList(await _realEstateService.GetRealEstateName(), "Id", "Name");

            return View(dto);
        }



        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewData["realEstate"] = new SelectList(await _realEstateService.GetRealEstateName(), "Id", "Name");
            var auctionDb = await _auctionService.Get(id);
            return View(auctionDb);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateAuctionDto dto)
        {
            if (ModelState.IsValid)
            {
                await _auctionService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            ViewData["realEstate"] = new SelectList(await _realEstateService.GetRealEstateName(), "Id", "Name");
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



        public async Task<IActionResult> GetLog(int Id)
        {
            var logs = await _auctionService.GetLog(Id);
            return View(logs);
        }


        [HttpGet]
        public async Task<IActionResult> RemoveAttachment(int id)
        {
            await _auctionService.RemoveAttachment(id);
            return Ok(Results.DeleteSuccessResult());
        }
    }
}