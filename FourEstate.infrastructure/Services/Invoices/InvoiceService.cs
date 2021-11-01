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

namespace FourEstate.infrastructure.Services.Invoices
{
    public class InvoiceService :IInvoiceServices
    {
        private readonly FourEstateDbContext _db;
        private readonly IMapper _mapper;

        public InvoiceService(FourEstateDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Invoices.Include(x => x.Customer).Include(x => x.RealEstate).Include(x=>x.User).Where(x => !x.IsDelete && (x.InvoiceNumber.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var invoice = _mapper.Map<List<InvoiceViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = invoice,
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



        public async Task<int> Create(CreateInvoiceDto dto)
        {
            var invoice = _mapper.Map<Invoice>(dto);
            await _db.Invoices.AddAsync(invoice);
            await _db.SaveChangesAsync();
            return invoice.Id;
        }


        public async Task<int> Update(UpdateInvoiceDto dto)
        {
            var invoice = await _db.Invoices.SingleOrDefaultAsync(x => !x.IsDelete && x.Id == dto.Id);
            if (invoice == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedInvoice = _mapper.Map<UpdateInvoiceDto, Invoice>(dto, invoice);

            _db.Invoices.Update(updatedInvoice);
            await _db.SaveChangesAsync();
            return updatedInvoice.Id;
        }


        public async Task<UpdateInvoiceDto> Get(int Id)
        {
            var invoice = await _db.Invoices.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (invoice == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateInvoiceDto>(invoice);
        }


        public async Task<int> Delete(int Id)
        {
            var invoice = await _db.Invoices.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (invoice == null)
            {
                throw new EntityNotFoundException();
            }
            invoice.IsDelete = true;
            _db.Invoices.Update(invoice);
            await _db.SaveChangesAsync();
            return invoice.Id;
        }



        public async Task<byte[]> ExportToExcel()
        {
            var invoice = await _db.Invoices.Where(x => !x.IsDelete).ToListAsync();

            return ExcelHelpers.ToExcel(new Dictionary<string, ExcelColumn>
            {
                {"InvoiceNumber", new ExcelColumn("InvoiceNumber", 0)},
                {"InvoiceType", new ExcelColumn("InvoiceType", 1)},
                {"Quentity", new ExcelColumn("Quentity", 2)}
            }, new List<ExcelRow>(invoice.Select(e => new ExcelRow
            {
                Values = new Dictionary<string, string>
                {
                    {"InvoiceNumber", e.InvoiceNumber},
                    {"InvoiceType", e.InvoiceType.ToString()},
                     {"Quentity", e.Quentity.ToString()}
                }
            })));
        }


    }
}
