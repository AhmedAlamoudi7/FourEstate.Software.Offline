﻿using FourEstate.Core.Constants;
using FourEstate.Core.Dtos;
using FourEstate.Infrastructure.Services.Categories;
using FourEstate.Infrastructure.Services.LocationsService;
using FourEstate.Infrastructure.Services.REAlEstate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourEstate.Web.Controllers
{
    public class RealEstateController : Controller
    {
     
        private readonly IRealEstateService _realEstateService;
        private readonly ICategoryService _categoryService;
        private readonly ILocationService _locationService;

        public RealEstateController(IRealEstateService realEstateService, ICategoryService categoryService, ILocationService locationService)
        {
            _realEstateService = realEstateService;
            _categoryService = categoryService;
            _locationService = locationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetRealEstateData(Pagination pagination, Query query)
        {
            var result = await _realEstateService.GetAll(pagination, query);
            return Json(result);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["category"] = new SelectList(await _categoryService.GetCategoryName(), "Id", "Name");
            ViewData["location"] = new SelectList(await _locationService.GetLocationCountry(), "Id", "Country");

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateRealEstateDto dto)
        {

            if (ModelState.IsValid)
            {
                ViewData["category"] = new SelectList(await _categoryService.GetCategoryName(), "Id", "Name");
                ViewData["location"] = new SelectList(await _locationService.GetLocationCountry(), "Id", "Country");
                await _realEstateService.Create(dto);
                return Ok(Results.AddSuccessResult());
             
            }
           
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewData["category"] = new SelectList(await _categoryService.GetCategoryName(), "Id", "Name");
            ViewData["location"] = new SelectList(await _locationService.GetLocationCountry(), "Id", "Country");
            var user = await _realEstateService.Get(id);
            return View(user);
         
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateRealEstateDto dto)
        {
            if (ModelState.IsValid)
            {
                ViewData["category"] = new SelectList(await _categoryService.GetCategoryName(), "Id", "Name");
                ViewData["location"] = new SelectList(await _locationService.GetLocationCountry(), "Id", "Country");
                await _realEstateService.Update(dto);
                return Ok(Results.EditSuccessResult());
    
            }
     
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _realEstateService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }

    }
}
