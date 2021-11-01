using FourEstate.Core.Dtos;
using FourEstate.Core.Enums;
using FourEstate.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.infrastructure.Services.RentContracts
{
    public interface IRentContractService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<List<RentContractViewModel>> GetAllAPI(string serachKey);
        Task<List<ContentChangeLogViewModel>> GetLog(int id);
        Task<List<RentContractViewModel>> GetRentContractName();
        Task<int> Create(CreateRentContractDto dto);
        Task<int> Update(UpdateRentContractDto dto);
        Task<UpdateRentContractDto> Get(int Id);
        Task<int> Delete(int Id);
        Task<int> UpdateStatus(int id, ContentStatus status);
        Task<byte[]> ExportToExcel();
    }
}
