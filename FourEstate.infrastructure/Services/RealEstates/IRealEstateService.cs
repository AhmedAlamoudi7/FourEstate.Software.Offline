using FourEstate.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Infrastructure.Services.RealEstates

{
    public interface IRealEstateService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);

        Task<int> Create(CreateRealEstateDto dto);

        Task<int> Update(UpdateRealEstateDto dto);

        Task<UpdateRealEstateDto> Get(int Id);

        Task<int> Delete(int Id);
    }
}
