using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PlaceApp.Places
{
    public interface IPlaceTypeAppService : IApplicationService
    {
        Task<PagedResultDto<PlaceTypeDto>> GetListAsync(GetListPlaceType input);
        Task<PlaceTypeReponseDto> CreateAsync(PlaceTypeRequestDto place);
    }
}
