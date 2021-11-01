using FourEstate.Core.Dtos;
using FourEstate.Core.Enums;
using FourEstate.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.infrastructure.Services.Auctions
{
    public interface IAuctionService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<List<AuctionDbViewModel>> GetAllAPI(string serachKey);
        Task<int> Create(CreateAuctionDto dto);
        Task<int> Update(UpdateAuctionDto dto);
        Task<UpdateAuctionDto> Get(int Id);
        Task<int> Delete(int Id);
        Task<int> UpdateStatus(int id, ContentStatus status);
        Task<byte[]> ExportToExcel();
        Task<List<ContentChangeLogViewModel>> GetLog(int id);
        Task<int> RemoveAttachment(int id);
    }
}
