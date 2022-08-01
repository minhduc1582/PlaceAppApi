using Microsoft.AspNetCore.Mvc;
using PlaceApp.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceApp.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceAppService _placeAppService;
        public PlaceController(IPlaceAppService placeAppService)
        {
            _placeAppService = placeAppService;
        }
        [Route("place-types")]
        [HttpPost]
        public async Task<PlaceRequestReponseDto> CreatePlaceAuto(PlaceAuto input)
        {
            PlaceRequestReponseDto placeRequestReponseDto= new PlaceRequestReponseDto();
            placeRequestReponseDto.PlaceType = input.place_type;
            placeRequestReponseDto.Name = input.place_type_name;
            placeRequestReponseDto.Source = "Auto";
            return await _placeAppService.CreateAsync(placeRequestReponseDto);
        }
        public class PlaceAuto
        {
            public string place_type { get; set; }
            public string place_type_name { get; set; }
        }
    }
}
