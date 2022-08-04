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
        Task<PagedResultDto<PlaceDto>> GetListByStatusTypeAsync(GetListPlace input,StatusType statusType);
        Task<PlaceDto> CreateAsync(PlaceRequestDto place);
        Task<PlaceDto> CreateModeSourceAsync(PlaceRequestDto place, int mode = 0);
        Task<PlaceDto> UpdateAsync(Guid id, StatusType statusType);
    }
}
