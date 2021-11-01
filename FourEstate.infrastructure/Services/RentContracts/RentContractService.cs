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

namespace FourEstate.infrastructure.Services.RentContracts
{
    public class RentContractService :IRentContractService
    {
        private readonly FourEstateDbContext _db;
        private readonly IMapper _mapper;

        public RentContractService(FourEstateDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.RentContracts.Include(x => x.RealEstate).Include(x => x.Customer)
                .Where(x => !x.IsDelete && (x.Customer.FullName.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch)))
                .AsQueryable();


            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var rentcontracts = _mapper.Map<List<RentContractViewModel>>(dataList);

            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = rentcontracts,
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

        public async Task<List<RentContractViewModel>> GetAllAPI(string serachKey)
        {
            var rentcontract = await _db.Contracts
                .Include(x => x.Customer)
                .Include(x => x.RealEstate).ThenInclude(x => x.Location)
                .Include(x => x.RealEstate).ThenInclude(x => x.Category)
                .Where(x => x.Stauts.ToString().Contains(serachKey) || string.IsNullOrWhiteSpace(serachKey))
                .ToListAsync();
            return _mapper.Map<List<RentContractViewModel>>(rentcontract);
        }


        public async Task<List<ContentChangeLogViewModel>> GetLog(int id)
        {
            var changes = await _db.ContentChangeLogs.Where(x => x.ContentId == id).ToListAsync();
            return _mapper.Map<List<ContentChangeLogViewModel>>(changes);
        }



        public async Task<List<RentContractViewModel>> GetRentContractName()
        {
            var rentcontract = await _db.RentContracts.Where(x => !x.IsDelete).ToListAsync();
            return _mapper.Map<List<RentContractViewModel>>(rentcontract);
        }



        public async Task<int> Create(CreateRentContractDto dto)
        {
            var rentcontract = _mapper.Map<CreateRentContractDto, RentContract>(dto);
            await _db.RentContracts.AddAsync(rentcontract);
            await _db.SaveChangesAsync();
            return rentcontract.Id;
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

        public async Task<int> Update(UpdateRentContractDto dto)
        {
            var salecontract = await _db.RentContracts.SingleOrDefaultAsync(x => !x.IsDelete && x.Id == dto.Id);
            if (salecontract == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedsalecontract = _mapper.Map<UpdateRentContractDto, RentContract>(dto, salecontract);
            _db.RentContracts.Update(updatedsalecontract);
            await _db.SaveChangesAsync();
            return updatedsalecontract.Id;
        }

        public async Task<UpdateRentContractDto> Get(int Id)
        {
            var rentcontract = await _db.RentContracts.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (rentcontract == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateRentContractDto>(rentcontract);
        }


        public async Task<int> Delete(int Id)
        {
            var rentcontract = await _db.RentContracts.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (rentcontract == null)
            {
                throw new EntityNotFoundException();
            }
            rentcontract.IsDelete = true;
            _db.RentContracts.Update(rentcontract);
            await _db.SaveChangesAsync();
            return rentcontract.Id;
        }




        public async Task<int> UpdateStatus(int id, ContentStatus status)
        {
            var rentcontract = await _db.RentContracts.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (rentcontract == null)
            {
                throw new EntityNotFoundException();
            }

            var changeLog = new ContentChangeLog();
            changeLog.ContentId = rentcontract.Id;
            changeLog.Type = ContentType.RentContract;
            changeLog.Old = rentcontract.Stauts;
            changeLog.New = status;
            changeLog.ChangeAt = DateTime.Now;

            await _db.ContentChangeLogs.AddAsync(changeLog);
            await _db.SaveChangesAsync();


            rentcontract.Stauts = status;
            _db.RentContracts.Update(rentcontract);
            await _db.SaveChangesAsync();

            //await _emailService.Send(post.Author.Email, "UPDATE POST STATUS !", $"YOUR POST NOW IS {status.ToString()}");

            return rentcontract.Id;
        }

        public async Task<byte[]> ExportToExcel()
        {
            var rentContract = await _db.RentContracts.Include(x => x.Customer).Include(x => x.RealEstate).Where(x => !x.IsDelete).ToListAsync();

            return ExcelHelpers.ToExcel(new Dictionary<string, ExcelColumn>
            {
                {"Price", new ExcelColumn("Price", 0)},
                {"FormulaContract", new ExcelColumn("FormulaContract", 1)},
                {"RealEstate", new ExcelColumn("RealEstate", 2)},
                {"Customer", new ExcelColumn("Customer", 3)}
            }, new List<ExcelRow>(rentContract.Select(e => new ExcelRow
            {
                Values = new Dictionary<string, string>
                {
                    {"Price", e.DateTimeEndRent.ToString()},
                    {"FormulaContract", e.FormulaContract.ToString()},
                    {"RealEstate", e.RealEstate.Name},
                    {"Customer", e.Customer.FullName}
                }
            })));
        }

    }
}




