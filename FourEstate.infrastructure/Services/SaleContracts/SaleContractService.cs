using AutoMapper;
using FourEstate.Core.Dtos;
using FourEstate.Core.Enums;
using FourEstate.Core.Exceptions;
using FourEstate.Core.ViewModels;
using FourEstate.Data;
using FourEstate.Data.Models;
using FourEstate.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.infrastructure.Services.SaleContracts
{
    public class SaleContractService :ISaleContractService
    {
        private readonly FourEstateDbContext _db;
        private readonly IMapper _mapper;

        public SaleContractService(FourEstateDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.SaleContracts.Include(x => x.RealEstate).Include(x => x.Customer).Include(x=>x.User)
                .Where(x => !x.IsDelete && (x.Customer.FullName.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch)))
                .AsQueryable();


            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var salecontracts = _mapper.Map<List<SaleContractViewModel>>(dataList);

            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = salecontracts,
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

        public async Task<List<SaleContractViewModel>> GetAllAPI(string serachKey)
        {
            var contract = await _db.Contracts
                .Include(x => x.Customer)
                .Include(x => x.RealEstate).ThenInclude(x => x.Location)
                .Include(x => x.RealEstate).ThenInclude(x => x.Category)
                .Where(x => x.Stauts.ToString().Contains(serachKey) || string.IsNullOrWhiteSpace(serachKey))
                .ToListAsync();
            return _mapper.Map<List<SaleContractViewModel>>(contract);
        }


        public async Task<List<ContentChangeLogViewModel>> GetLog(int id)
        {
            var changes = await _db.ContentChangeLogs.Where(x => x.ContentId == id).ToListAsync();
            return _mapper.Map<List<ContentChangeLogViewModel>>(changes);
        }



        public async Task<List<SaleContractViewModel>> GetSaleContractName()
        {
            var salecontract = await _db.Contracts.Where(x => !x.IsDelete).ToListAsync();
            return _mapper.Map<List<SaleContractViewModel>>(salecontract);
        }



        public async Task<int> Create(CreateSaleContractDto dto)
        {
            var salecontract = _mapper.Map<CreateSaleContractDto, SaleContract>(dto);
            await _db.SaleContracts.AddAsync(salecontract);
            await _db.SaveChangesAsync();
            return salecontract.Id;
        }
        //public async Task<int> Create(CreateSaleContractDto dto)
        //{
        //    var contract = new Contract();
        //    contract.ContractType = dto.ContractType;
        //    contract.CustomerId = dto.CustomerId;
        //    contract.RealEstateId = dto.RealEstatedId;
        //    contract.Price = dto.Price;
        //    contract.CreatedAt = DateTime.Now;
        //    await _db.Contracts.AddAsync(contract);
        //    await _db.SaveChangesAsync();
        //    return contract.Id;
        //}

        public async Task<int> Update(UpdateSaleContractDto dto)
        {
            var salecontract = await _db.SaleContracts.SingleOrDefaultAsync(x => !x.IsDelete && x.Id == dto.Id);
            if (salecontract == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedsalecontract = _mapper.Map<UpdateSaleContractDto, SaleContract>(dto, salecontract);
            _db.SaleContracts.Update(updatedsalecontract);
            await _db.SaveChangesAsync();
            return updatedsalecontract.Id;
        }


        public async Task<UpdateSaleContractDto> Get(int Id)
        {
            var salecontract = await _db.SaleContracts.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (salecontract == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateSaleContractDto>(salecontract);
        }


        public async Task<int> Delete(int Id)
        {
            var salecontract = await _db.SaleContracts.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (salecontract == null)
            {
                throw new EntityNotFoundException();
            }
            salecontract.IsDelete = true;
            _db.SaleContracts.Update(salecontract);
            await _db.SaveChangesAsync();
            return salecontract.Id;
        }




        public async Task<int> UpdateStatus(int id, ContentStatus status)
        {
            var salecontract = await _db.SaleContracts.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (salecontract == null)
            {
                throw new EntityNotFoundException();
            }

            var changeLog = new ContentChangeLog();
            changeLog.ContentId = salecontract.Id;
            changeLog.Type = Core.Enums.ContentType.SaleContract;
            changeLog.Old = salecontract.Stauts;
            changeLog.New = status;
            changeLog.ChangeAt = DateTime.Now;

            await _db.ContentChangeLogs.AddAsync(changeLog);
            await _db.SaveChangesAsync();


            salecontract.Stauts = status;
            _db.SaleContracts.Update(salecontract);
            await _db.SaveChangesAsync();

            //await _emailService.Send(post.Author.Email, "UPDATE POST STATUS !", $"YOUR POST NOW IS {status.ToString()}");

            return salecontract.Id;
        }

        public async Task<byte[]> ExportToExcel()
        {
            var saleContract = await _db.SaleContracts.Include(x => x.Customer).Include(x => x.RealEstate).Where(x => !x.IsDelete).ToListAsync();

            return ExcelHelpers.ToExcel(new Dictionary<string, ExcelColumn>
            {
                {"Price", new ExcelColumn("Price", 0)},
                {"FormulaContract", new ExcelColumn("FormulaContract", 1)},
                {"RealEstate", new ExcelColumn("RealEstate", 2)},
                {"Customer", new ExcelColumn("Customer", 3)}
            }, new List<ExcelRow>(saleContract.Select(e => new ExcelRow
            {
                Values = new Dictionary<string, string>
                {
                    {"Price", e.Price.ToString()},
                    {"FormulaContract", e.FormulaContract.ToString()},
                    {"RealEstate", e.RealEstate.Name},
                    {"Customer", e.Customer.FullName}
                }
            })));
        }

    }
}



