using FourEstate.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.infrastructure.Services.Invoices
{
    public interface IInvoiceServices
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<int> Create(CreateInvoiceDto dto);
        Task<int> Update(UpdateInvoiceDto dto);
        Task<UpdateInvoiceDto> Get(int Id);
        Task<int> Delete(int Id);
        Task<byte[]> ExportToExcel();
    }
}
