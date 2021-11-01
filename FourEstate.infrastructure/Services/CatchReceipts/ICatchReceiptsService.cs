using FourEstate.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.infrastructure.Services.CatchReceipts
{
   public interface ICatchReceiptService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<int> Create(CreateCatchReceiptDto dto);
        Task<int> Update(UpdateCatchReceiptDto dto);
        Task<UpdateCatchReceiptDto> Get(int Id);
        Task<int> Delete(int Id);
        Task<byte[]> ExportToExcel();
        }
}
