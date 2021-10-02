using AutoMapper;
using FourEstate.Core.Dtos;
using FourEstate.Core.Enums;
using FourEstate.Core.Exceptions;
using FourEstate.Core.ViewModels;
using FourEstate.Data;
using FourEstate.Data.Models;
using FourEstate.Infrastructure.Services.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Infrastructure.Services.ContractServices
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
            var queryString = _db.Contracts.Include(x => x.RealEstate).Include(c=>c.Customer).Where(x => !x.IsDelete).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var contract = _mapper.Map<List<ContractViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = contract,
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

        public async Task<int> Delete(int id)
        {
            var contract = await _db.Contracts.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if(contract == null)
            {
                throw new EntityNotFoundException();
            }
            contract.IsDelete = true;
            _db.Contracts.Update(contract);
            await _db.SaveChangesAsync();
            return contract.Id;
        }

        public async Task<UpdateContractDto> Get(int id)
        {
            var contract = await _db.Contracts.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);
            if (contract == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateContractDto>(contract);
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
            var contract = await _db.Contracts.SingleOrDefaultAsync(x => x.Id == dto.Id && !x.IsDelete);
            if(contract == null)
            {
                throw new EntityNotFoundException();
            }

            var updatedContract = _mapper.Map(dto, contract);

           
             _db.Contracts.Update(updatedContract);
             await _db.SaveChangesAsync();

            return contract.Id;
        }

    }
}
