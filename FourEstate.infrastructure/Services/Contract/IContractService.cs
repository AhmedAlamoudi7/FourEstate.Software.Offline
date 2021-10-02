using FourEstate.Core.Dtos;
using FourEstate.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Infrastructure.Services.ContractServices
{
    public interface IContractService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<int> Delete(int id);
        Task<int> Create(CreateContractDto dto);
        Task<UpdateContractDto> Get(int id);
        Task<int> Update(UpdateContractDto dto);


        
        }
}
