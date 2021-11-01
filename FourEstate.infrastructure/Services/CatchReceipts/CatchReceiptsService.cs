using AutoMapper;
using FourEstate.Core.Dtos;
using FourEstate.Core.Exceptions;
using FourEstate.Core.ViewModels;
using FourEstate.Data;
using FourEstate.Data.Models;
using FourEstate.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.infrastructure.Services.CatchReceipts
{
    public class CatchReceiptsService : ICatchReceiptService
    {
        private readonly FourEstateDbContext _db;
        private readonly IMapper _mapper;

        public CatchReceiptsService(FourEstateDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.CatchReceipts.Include(x=>x.Customer)
                .Include(x=>x.User)
                .Include(x=>x.RealEstate)
                .Include(x=>x.RentContract)
                .Where(x => !x.IsDelete && (x.statment.ToString().Contains(query.GeneralSearch) ||
            string.IsNullOrWhiteSpace(query.GeneralSearch)))
           .AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var catchreceipts = _mapper.Map<List<CatchReceiptViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = catchreceipts,
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

        public async Task<int> Create(CreateCatchReceiptDto dto)
        {
            var catchreceipt = _mapper.Map<CatchReceipt>(dto);
            await _db.CatchReceipts.AddAsync(catchreceipt);
            await _db.SaveChangesAsync();
            return catchreceipt.Id;
        }


        public async Task<int> Update(UpdateCatchReceiptDto dto)
        {
            var catchreceipt = await _db.CatchReceipts.SingleOrDefaultAsync(x => !x.IsDelete && x.Id == dto.Id);
            if (catchreceipt == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedcatchreceipt = _mapper.Map<UpdateCatchReceiptDto, CatchReceipt>(dto, catchreceipt);

            _db.CatchReceipts.Update(updatedcatchreceipt);
            await _db.SaveChangesAsync();
            return updatedcatchreceipt.Id;
        }


        public async Task<UpdateCatchReceiptDto> Get(int Id)
        {
            var catchreceipt = await _db.CatchReceipts.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (catchreceipt == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateCatchReceiptDto>(catchreceipt);
        }


        public async Task<int> Delete(int Id)
        {
            var catchreceipt = await _db.CatchReceipts.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (catchreceipt == null)
            {
                throw new EntityNotFoundException();
            }
            catchreceipt.IsDelete = true;
            _db.CatchReceipts.Update(catchreceipt);
            await _db.SaveChangesAsync();
            return catchreceipt.Id;
        }



        public async Task<byte[]> ExportToExcel()
        {
            var catchreceipt = await _db.CatchReceipts
                .Include(x => x.User)
                .Include(x => x.RealEstate)
                .Include(x => x.RentContract).Where(x => !x.IsDelete).ToListAsync();

            return ExcelHelpers.ToExcel(new Dictionary<string, ExcelColumn>
            {
                {"statment", new ExcelColumn("statment", 0)},
                {"InvoiceType", new ExcelColumn("InvoiceType", 1)},
                {"ReceiptNumber", new ExcelColumn("ReceiptNumber", 2)}
            }, new List<ExcelRow>(catchreceipt.Select(e => new ExcelRow
            {
                Values = new Dictionary<string, string>
                {
                    {"statment", e.statment},
                    {"InvoiceType", e.InvoiceType.ToString()},
                     {"ReceiptNumber", e.ReceiptNumber.ToString()}
                }
            })));
        }


    }
}
