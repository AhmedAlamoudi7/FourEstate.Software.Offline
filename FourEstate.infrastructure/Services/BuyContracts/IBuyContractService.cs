using FourEstate.Core.Dtos;
using FourEstate.Core.Enums;
using FourEstate.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.infrastructure.Services.BuyContracts
{
    public interface IBuyContractService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<List<BuyContractViewModel>> GetAllAPI(string serachKey);
        Task<List<ContentChangeLogViewModel>> GetLog(int id);
        Task<List<BuyContractViewModel>> GetBuyContractName();
        Task<int> Create(CreateBuyContractDto dto);
        Task<int> Update(UpdateBuyContractDto dto);
        Task<UpdateBuyContractDto> Get(int Id);
        Task<int> Delete(int Id);
        Task<int> UpdateStatus(int id, ContentStatus status);
        Task<byte[]> ExportToExcel();
    }
}
