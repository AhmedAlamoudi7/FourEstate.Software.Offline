using AutoMapper;
using FourEstate.Core.Dtos;
using FourEstate.Core.Exceptions;
using FourEstate.Core.ViewModels;
using FourEstate.Data;
using FourEstate.Data.Models;
using FourEstate.Infrastructure.Helpers;
using FourEstate.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.infrastructure.Services.Holidays
{
    public class HolidayService : IHolidayService
    {
        private readonly FourEstateDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public HolidayService(FourEstateDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }



        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Holidays.Where(x => !x.IsDelete && (x.From.ToString().Contains(query.GeneralSearch) ||
            x.To.ToString().Contains(query.GeneralSearch) ||
            string.IsNullOrWhiteSpace(query.GeneralSearch)))
           .AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var holiday = _mapper.Map<List<HolidayViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = holiday,
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


        public async Task<List<HolidayViewModel>> GetAllAPI(string serachKey)
        {
            var holiday = await _db.Holidays.Where(x => x.From.ToString().Contains(serachKey) ||
            x.To.ToString().Contains(serachKey)  ||
            string.IsNullOrWhiteSpace(serachKey))
            .ToListAsync();
            return _mapper.Map<List<HolidayViewModel>>(holiday);
        }
      
        public async Task<List<HolidayViewModel>> GetHolidayTitle()
        {
            var holiday = await _db.Holidays.Where(x => !x.IsDelete).ToListAsync();
            return _mapper.Map<List<HolidayViewModel>>(holiday);
        }





        public async Task<int> Create(CreateHolidayDto dto)
        {
            var holiday = _mapper.Map<Holiday>(dto);
            await _db.Holidays.AddAsync(holiday);
            await _db.SaveChangesAsync();
            return holiday.Id;
        }


        public async Task<int> Update(UpdateHolidayDto dto)
        {
            var holiday = await _db.Holidays.SingleOrDefaultAsync(x => !x.IsDelete && x.Id == dto.Id);
            if (holiday == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedHoliday = _mapper.Map<UpdateHolidayDto, Holiday>(dto, holiday);
         
            _db.Holidays.Update(updatedHoliday);
            await _db.SaveChangesAsync();
            return updatedHoliday.Id;
        }


        public async Task<UpdateHolidayDto> Get(int Id)
        {
            var holiday = await _db.Holidays.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (holiday == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateHolidayDto>(holiday);
        }


        public async Task<int> Delete(int Id)
        {
            var holiday = await _db.Holidays.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (holiday == null)
            {
                throw new EntityNotFoundException();
            }
            holiday.IsDelete = true;
            _db.Holidays.Update(holiday);
            await _db.SaveChangesAsync();
            return holiday.Id;
        }



        public async Task<byte[]> ExportToExcel()
        {
            var holiday = await _db.Holidays.Where(x => !x.IsDelete).ToListAsync();

            return ExcelHelpers.ToExcel(new Dictionary<string, ExcelColumn>
            {
                {"Title", new ExcelColumn("Title", 0)},
                {"From", new ExcelColumn("From", 1)},
                {"To", new ExcelColumn("To", 2)}
            }, new List<ExcelRow>(holiday.Select(e => new ExcelRow
            {
                Values = new Dictionary<string, string>
                {
                    {"Title", e.Title},
                    {"From", e.From.ToString()},
                     {"To", e.To.ToString()}
                }
            })));
        }

    }
}

 
