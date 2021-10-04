using FourEstate.Core.Dtos;
using FourEstate.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.infrastructure.Services.ContractSS
{
 public interface IContractService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<int> Delete(int Id);
        Task<UpdateContractDto> Get(int Id);
        Task<int> Update(UpdateContractDto dto);
        Task<int> Create(CreateContractDto dto);
        Task<List<ContractViewModel>> GetContractName();
    }
}
