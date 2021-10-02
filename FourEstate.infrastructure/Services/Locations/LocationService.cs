using AutoMapper;
using FourEstate.Core.Dtos;
using FourEstate.Core.Exceptions;
using FourEstate.Core.ViewModels;
using FourEstate.Data;
using FourEstate.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Infrastructure.Services.LocationsService
{
    public class LocationService : ILocationService
    {
        private readonly FourEstateDbContext _db;
        private readonly IMapper _mapper;

        public LocationService(FourEstateDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Locations.Where(x => !x.IsDelete && (x.Country.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var location = _mapper.Map<List<LocationViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = location,
                meta = new Meta
                {
                    page = pagination.Page,
                    perpage = pagination.PerPage,
                    pages = pages,
                    total = dataCount,
                }
            };
            return result;
        }

        public async Task<List<LocationViewModel>> GetLocationCountry()
        {
            var location = await _db.Locations.Where(x => !x.IsDelete).ToListAsync();
            return _mapper.Map<List<LocationViewModel>>(location);
        }

        public async Task<int> Create(CreateLocationDto dto)
        {
            var location = _mapper.Map<Location>(dto);
            await _db.Locations.AddAsync(location);
            await _db.SaveChangesAsync();
            return location.Id;
        }

        public async Task<int> Update(UpdateLocationDto dto)
        {
            var location= await _db.Locations.SingleOrDefaultAsync(x => !x.IsDelete && x.Id == dto.Id);
            if (location == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedLocation = _mapper.Map<UpdateLocationDto, Location>(dto, location);
          
            _db.Locations.Update(updatedLocation);
            await _db.SaveChangesAsync();
            return updatedLocation.Id;
        }


        public async Task<UpdateLocationDto> Get(int Id)
        {
            var location = await _db.Locations.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (location == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateLocationDto>(location);
        }

              public async Task<int>Delete(int Id) {
            var location = await _db.Locations.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (location == null)
            {
                throw new EntityNotFoundException();
            }
            location.IsDelete = true;
            _db.Locations.Update(location);
            await _db.SaveChangesAsync();
            return location.Id;
        }


    }
}
