using FourEstate.Core.Dtos;
using FourEstate.Core.Enums;
using FourEstate.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.infrastructure.Services.SaleContracts
{
    public interface ISaleContractService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<List<SaleContractViewModel>> GetAllAPI(string serachKey);
        Task<List<ContentChangeLogViewModel>> GetLog(int id);
        Task<List<SaleContractViewModel>> GetSaleContractName();
        Task<int> Create(CreateSaleContractDto dto);
        Task<int> Update(UpdateSaleContractDto dto);
        Task<UpdateSaleContractDto> Get(int Id);
        Task<int> Delete(int Id);
        Task<int> UpdateStatus(int id, ContentStatus status);
        Task<byte[]> ExportToExcel();

    }
}
