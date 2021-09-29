using FourEstate.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourEstate.Infrastructure.Services.Locations
{
    public interface ILocationService
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);

        Task<int> Create(CreateLocationDto dto);

        Task<int> Update(UpdateLocationDto dto);

        Task<UpdateLocationDto> Get(int Id);

        Task<int> Delete(int Id);
    }
}
