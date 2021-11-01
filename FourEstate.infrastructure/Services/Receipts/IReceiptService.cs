using FourEstate.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.infrastructure.Services.Receipts
{
   public interface IReceiptService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<int> Create(CreateReceiptDto dto);
        Task<int> Update(UpdateReceiptDto dto);
        Task<UpdateReceiptDto> Get(int Id);
        Task<int> Delete(int Id);
        Task<byte[]> ExportToExcel();
        }
}
