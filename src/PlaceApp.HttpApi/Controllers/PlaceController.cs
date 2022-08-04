using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using PlaceApp.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PlaceApp.Controllers
{
    [Route("api/v1/")]
    [ApiController]

    public class PlaceController : ControllerBase
    {
        private readonly IPlaceAppService _placeAppService;
        readonly ITokenAcquisition tokenAcquisition;

        public PlaceController(IPlaceAppService placeAppService, ITokenAcquisition tokenAcquisition)
        {
            _placeAppService = placeAppService;
            this.tokenAcquisition = tokenAcquisition;

        }
        [Route("place-types")]
        [HttpPost]
        public async Task<PlaceDto> CreatePlaceAuto(PlaceRequestDto input)
        {
            return await _placeAppService.CreateModeSourceAsync(input,1);
        }
    }
}
