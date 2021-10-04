using FourEstate.Core.Dtos;
using FourEstate.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Infrastructure.Services.REAlEstate
{
    public interface IRealEstateService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);

        Task<int> Delete(int id);
        Task<UpdateRealEstateDto> Get(int id);
        Task<int> Create(CreateRealEstateDto dto);
        Task<int> Update(UpdateRealEstateDto dto);
        Task<List<RealEstateViewModel>> GetRealEstateName();

    }
}
