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

namespace FourEstate.infrastructure.Services.Receipts
{
    public class ReceiptService :IReceiptService
    {
        private readonly FourEstateDbContext _db;
        private readonly IMapper _mapper;

        public ReceiptService(FourEstateDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }





        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Receipts.Include(x=>x.Customer)
                .Include(x=>x.User)
                .Include(x=>x.RealEstate)
                .Include(x=>x.RentContract)
                .Where(x => !x.IsDelete && (x.statment.ToString().Contains(query.GeneralSearch) ||
            string.IsNullOrWhiteSpace(query.GeneralSearch)))
           .AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var receipts = _mapper.Map<List<ReceiptViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = receipts,
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

        public async Task<int> Create(CreateReceiptDto dto)
        {
            var receipt = _mapper.Map<Receipt>(dto);
            await _db.Receipts.AddAsync(receipt);
            await _db.SaveChangesAsync();
            return receipt.Id;
        }


        public async Task<int> Update(UpdateReceiptDto dto)
        {
            var receipt = await _db.Receipts.SingleOrDefaultAsync(x => !x.IsDelete && x.Id == dto.Id);
            if (receipt == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedReceipt = _mapper.Map<UpdateReceiptDto, Receipt>(dto, receipt);

            _db.Receipts.Update(updatedReceipt);
            await _db.SaveChangesAsync();
            return updatedReceipt.Id;
        }


        public async Task<UpdateReceiptDto> Get(int Id)
        {
            var receipt = await _db.Receipts.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (receipt == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateReceiptDto>(receipt);
        }


        public async Task<int> Delete(int Id)
        {
            var receipt = await _db.Receipts.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (receipt == null)
            {
                throw new EntityNotFoundException();
            }
            receipt.IsDelete = true;
            _db.Receipts.Update(receipt);
            await _db.SaveChangesAsync();
            return receipt.Id;
        }



        public async Task<byte[]> ExportToExcel()
        {
            var receipt = await _db.Receipts
                .Include(x => x.User)
                .Include(x => x.RealEstate)
                .Include(x => x.RentContract).Where(x => !x.IsDelete).ToListAsync();

            return ExcelHelpers.ToExcel(new Dictionary<string, ExcelColumn>
            {
                {"statment", new ExcelColumn("statment", 0)},
                {"InvoiceType", new ExcelColumn("InvoiceType", 1)},
                {"ReceiptNumber", new ExcelColumn("ReceiptNumber", 2)}
            }, new List<ExcelRow>(receipt.Select(e => new ExcelRow
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
