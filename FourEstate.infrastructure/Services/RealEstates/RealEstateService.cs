using AutoMapper;
using FourEstate.Core.Constants;
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

namespace FourEstate.Infrastructure.Services.RealEstates
{
    public class RealEstateService : IRealEstateService
    {
        private readonly FourEstateDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public RealEstateService(FourEstateDbContext db, IMapper mapper, IFileService fileService)
        {
            _db = db;
            _mapper = mapper;
            _fileService = fileService;
        }


        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.RealEstates.Where(x => !x.IsDelete && (x.Name.Contains(query.GeneralSearch)|| string.IsNullOrWhiteSpace(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var realEstate = _mapper.Map<List<RealEstateViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = realEstate,
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


        public async Task<int> Create(CreateRealEstateDto dto)
        {
            var realEstate = _mapper.Map<RealEstate>(dto);
            await _db.RealEstates.AddAsync(realEstate);
            await _db.SaveChangesAsync();

            if (dto.Images != null)
            {
                foreach (var img in dto.Images)
                {
                    var imgName = await _fileService.SaveFile(img, "Images");

                    var postImage = new Image();
                    postImage.RealEstateddId = realEstate.Id;
                    postImage.ImagePath = imgName;

                    await _db.Images.AddAsync(postImage);
                }
            }
            await _db.SaveChangesAsync();
           
      
            return realEstate.Id;
        }


        public async Task<int> Update(UpdateRealEstateDto dto)
        {
            var realEstate = await _db.RealEstates.SingleOrDefaultAsync(x => !x.IsDelete && x.Id == dto.Id);
            if(realEstate == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedrealEstate = _mapper.Map<UpdateRealEstateDto, RealEstate>(dto, realEstate);
            _db.RealEstates.Update(updatedrealEstate);
            await _db.SaveChangesAsync();
            if (dto.Images != null)
            {
                foreach (var img in dto.Images)
                {
                    var imgName = await _fileService.SaveFile(img, "Images");

                    var postImage = new Image();
                    postImage.RealEstateddId = realEstate.Id;
                    postImage.ImagePath = imgName;

                    await _db.Images.AddAsync(postImage);
                }
            }
            await _db.SaveChangesAsync();


            return updatedrealEstate.Id;
        }


        public async Task<UpdateRealEstateDto> Get(int Id)
        {
            var realEstate = await _db.RealEstates.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (realEstate == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateRealEstateDto>(realEstate);
        }


        public async Task<int> Delete(int Id)
        {
            var realEstate = await _db.RealEstates.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (realEstate == null)
            {
                throw new EntityNotFoundException();
            }
            realEstate.IsDelete = true;
            _db.RealEstates.Update(realEstate);
            await _db.SaveChangesAsync();
            return realEstate.Id;
        }


    }
}
