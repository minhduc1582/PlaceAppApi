using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PlaceApp.Places
{
    public interface IPlaceAppService : IApplicationService
    {
        Task<PagedResultDto<PlaceDto>> GetListAsync(GetListPlace input);
        Task<PlaceReponseDto> Create(PlaceRequestDto place);
    }
}
