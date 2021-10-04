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

namespace FourEstate.infrastructure.Services.ContractSS
{
    public class ContractService : IContractService
    {

        private readonly FourEstateDbContext _db;
        private readonly IMapper _mapper;

        public ContractService(FourEstateDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Contracts.Include(x => x.RealEstate).Include(x => x.Customer)
                .Where(x => !x.IsDelete && (x.Customer.FullName.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch)))
                .AsQueryable();


            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var contracts = _mapper.Map<List<ContractViewModel>>(dataList);

            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = contracts,
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


        public async Task<List<ContractViewModel>> GetContractName()
        {
            var contract = await _db.Contracts.Where(x => !x.IsDelete).ToListAsync();
            return _mapper.Map<List<ContractViewModel>>(contract);
        }



        public async Task<int> Create(CreateContractDto dto)
        {
            var contract = _mapper.Map<Contract>(dto);
            await _db.Contracts.AddAsync(contract);
            await _db.SaveChangesAsync();
            return contract.Id;
        }


        public async Task<int> Update(UpdateContractDto dto)
        {
            var contract = await _db.Contracts.SingleOrDefaultAsync(x => !x.IsDelete && x.Id == dto.Id);
            if (contract == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedcontract = _mapper.Map<UpdateContractDto, Contract>(dto, contract);
            _db.Contracts.Update(updatedcontract);
            await _db.SaveChangesAsync();
            return updatedcontract.Id;
        }


        public async Task<UpdateContractDto> Get(int Id)
        {
            var contract = await _db.Contracts.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (contract == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateContractDto>(contract);
        }


        public async Task<int> Delete(int Id)
        {
            var contract = await _db.Contracts.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (contract == null)
            {
                throw new EntityNotFoundException();
            }
            contract.IsDelete = true;
            _db.Contracts.Update(contract);
            await _db.SaveChangesAsync();
            return contract.Id;
        }


    }
}
