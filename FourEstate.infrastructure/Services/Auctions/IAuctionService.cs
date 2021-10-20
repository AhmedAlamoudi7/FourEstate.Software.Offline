using FourEstate.Core.Dtos;
using FourEstate.Core.Enums;
using FourEstate.Core.ViewModel;
using FourEstate.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Infrastructure.Services.Auctions
{
    public interface IAuctionService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<List<AuctionViewModel>> GetAllAPI(/*int page*/string serachKey);
        Task<int> Delete(int id);
        Task<UpdateAuctionDto> Get(int id);
        Task<int> Create(CreateAuctionDto dto);
        Task<int> Update(UpdateAuctionDto dto);
        Task<List<AuctionViewModel>> GetAuctionName();
        Task<int> UpdateStatus(int id, ContentStatus status);
        Task<List<ContentChangeLogViewModel>> GetLog(int id);
        Task<byte[]> ExportToExcel();
        Task<int> RemoveAttachment(int id);

    }
}
