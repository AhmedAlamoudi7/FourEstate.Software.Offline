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

namespace FourEstate.Infrastructure.Services.Locations
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
            var queryString = _db.Locations.Where(x => !x.IsDelete && (x.Country.Contains(query.GeneralSearch) || x.City.Contains(query.GeneralSearch) || x.Street.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var locations = _mapper.Map<List<LocationViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = locations,
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


        public async Task<int> Create(CreateLocationDto dto)
        {
            var locations = _mapper.Map<Location>(dto);
            await _db.Locations.AddAsync(locations);
            await _db.SaveChangesAsync();
            return locations.Id;
        }


        public async Task<int> Update(UpdateLocationDto dto)
        {
            var locations = await _db.Locations.SingleOrDefaultAsync(x => !x.IsDelete && x.Id == dto.Id);
            if(locations == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedLocations = _mapper.Map<UpdateLocationDto, Location>(dto, locations);
            _db.Locations.Update(updatedLocations);
            await _db.SaveChangesAsync();
            return updatedLocations.Id;
        }


        public async Task<UpdateLocationDto> Get(int Id)
        {
            var locations = await _db.Locations.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (locations == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateLocationDto>(locations);
        }


        public async Task<int> Delete(int Id)
        {
            var locations = await _db.Locations.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (locations == null)
            {
                throw new EntityNotFoundException();
            }
            locations.IsDelete = true;
            _db.Locations.Update(locations);
            await _db.SaveChangesAsync();
            return locations.Id;
        }


    }
}
