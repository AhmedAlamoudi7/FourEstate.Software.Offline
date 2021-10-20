using FourEstate.Core.Dtos;
using FourEstate.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.infrastructure.Services.Holidays
{
    public interface IHolidayService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<List<HolidayViewModel>> GetAllAPI(string serachKey);
        Task<List<HolidayViewModel>> GetHolidayTitle();
        Task<int> Create(CreateHolidayDto dto);
        Task<int> Update(UpdateHolidayDto dto);
        Task<UpdateHolidayDto> Get(int Id);
        Task<int> Delete(int Id);
        Task<byte[]> ExportToExcel();
    }
}
