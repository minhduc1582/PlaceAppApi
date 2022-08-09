using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace PlaceApp.Login
{
    public interface ILoginTokenResultAppService : IApplicationService
    {
        Task<LoginResultDto> LoginGetToken(UserLoginDto user);
    }
}
