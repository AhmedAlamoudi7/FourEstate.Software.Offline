﻿using FourEstate.Core.Constants;
using FourEstate.Core.Dtos;
using FourEstate.Infrastructure.Services.Categories;
using FourEstate.Infrastructure.Services.LocationsService;
using FourEstate.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourEstate.Web.Controllers
{
    public class LocationsController : Controller
    {

        private readonly ILocationService _locationService;
        
        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetLocationData(Pagination pagination,Query query)
        {
            var result = await _locationService.GetAll(pagination, query);
            return  Json(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLocationDto dto)
        {
            if (ModelState.IsValid)
            {
                await _locationService.Create(dto);
                return Ok(Results.AddSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var location = await _locationService.Get(id);
            return View(location);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateLocationDto dto)
        {
            if (ModelState.IsValid)
            {
                await _locationService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _locationService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }

    }
}