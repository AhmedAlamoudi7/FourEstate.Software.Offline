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
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.infrastructure.Services.BuyContracts
{
    public class BuyContractService :IBuyContractService
    {
        private readonly FourEstateDbContext _db;
        private readonly IMapper _mapper;

        public BuyContractService(FourEstateDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.BuyContracts.Include(x => x.RealEstate).Include(x => x.Customer).Include(x=>x.User)
                .Where(x => !x.IsDelete && (x.Customer.FullName.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch)))
                .AsQueryable();


            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var buycontracts = _mapper.Map<List<BuyContractViewModel>>(dataList);

            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = buycontracts,
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

        public async Task<List<BuyContractViewModel>> GetAllAPI(string serachKey)
        {
            var buycontract = await _db.Contracts
                .Include(x => x.Customer)
                .Include(x => x.RealEstate).ThenInclude(x => x.Location)
                .Include(x => x.RealEstate).ThenInclude(x => x.Category)
                .Where(x => x.Stauts.ToString().Contains(serachKey) || string.IsNullOrWhiteSpace(serachKey))
                .ToListAsync();
            return _mapper.Map<List<BuyContractViewModel>>(buycontract);
        }


        public async Task<List<ContentChangeLogViewModel>> GetLog(int id)
        {
            var changes = await _db.ContentChangeLogs.Where(x => x.ContentId == id).ToListAsync();
            return _mapper.Map<List<ContentChangeLogViewModel>>(changes);
        }



        public async Task<List<BuyContractViewModel>> GetBuyContractName()
        {
            var buycontract = await _db.BuyContracts.Where(x => !x.IsDelete).ToListAsync();
            return _mapper.Map<List<BuyContractViewModel>>(buycontract);
        }



        public async Task<int> Create(CreateBuyContractDto dto)
        {
            var buycontract = _mapper.Map<CreateBuyContractDto, BuyContract>(dto);
            await _db.BuyContracts.AddAsync(buycontract);
            await _db.SaveChangesAsync();
            return buycontract.Id;
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

        public async Task<int> Update(UpdateBuyContractDto dto)
        {
            var buycontract = await _db.BuyContracts.SingleOrDefaultAsync(x => !x.IsDelete && x.Id == dto.Id);
            if (buycontract == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedbuycontract = _mapper.Map<UpdateBuyContractDto, BuyContract>(dto, buycontract);
            _db.BuyContracts.Update(updatedbuycontract);
            await _db.SaveChangesAsync();
            return updatedbuycontract.Id;
        }


        public async Task<UpdateBuyContractDto> Get(int Id)
        {
            var buycontract = await _db.BuyContracts.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (buycontract == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateBuyContractDto>(buycontract);
        }


        public async Task<int> Delete(int Id)
        {
            var buycontract = await _db.BuyContracts.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (buycontract == null)
            {
                throw new EntityNotFoundException();
            }
            buycontract.IsDelete = true;
            _db.BuyContracts.Update(buycontract);
            await _db.SaveChangesAsync();
            return buycontract.Id;
        }




        public async Task<int> UpdateStatus(int id, ContentStatus status)
        {
            var buycontract = await _db.BuyContracts.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete );
            if (buycontract == null)
            {
                throw new EntityNotFoundException();
            }

            var changeLog = new ContentChangeLog();
            changeLog.Type = ContentType.BuyContract;
            changeLog.ContentId = buycontract.Id;
            changeLog.Old = buycontract.Stauts;
            changeLog.New = status;
            changeLog.ChangeAt = DateTime.Now;

            await _db.ContentChangeLogs.AddAsync(changeLog);
            await _db.SaveChangesAsync();


            buycontract.Stauts = status;
            _db.BuyContracts.Update(buycontract);
            await _db.SaveChangesAsync();

            //await _emailService.Send(post.Author.Email, "UPDATE POST STATUS !", $"YOUR POST NOW IS {status.ToString()}");

            return buycontract.Id;
        }

        public async Task<byte[]> ExportToExcel()
        {
            var buyContract = await _db.BuyContracts.Include(x => x.Customer).Include(x => x.RealEstate).Where(x => !x.IsDelete).ToListAsync();

            return ExcelHelpers.ToExcel(new Dictionary<string, ExcelColumn>
            {
                {"Price", new ExcelColumn("Price", 0)},
                {"FormulaContract", new ExcelColumn("FormulaContract", 1)},
                {"RealEstate", new ExcelColumn("RealEstate", 2)},
                {"Customer", new ExcelColumn("Customer", 3)}
            }, new List<ExcelRow>(buyContract.Select(e => new ExcelRow
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

