using FourEstate.Core.Dtos;
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
        //Task<int> Update(UpdateCategoryDto dto);

        //Task<UpdateCategoryDto> Get(int Id);

        //Task<int> Delete(int Id);
    }
}
