using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using PlaceApp.Places;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.IO;

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
        public async Task<PlaceDto> CreatePlaceAuto(PlaceRequestDto input)
        {
            return await _placeAppService.CreateModeSourceAsync(input,1);
        }
        [Route("export-place")]
        [HttpGet]
        public async Task<IActionResult> Export()
        {
            GetListPlace input = new GetListPlace { SkipCount = 0, MaxResultCount = int.MaxValue, Sorting = "Name",Filter = "" };
            var  places = await _placeAppService.ExportData();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Name");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = " Place Type Name";
                worksheet.Cell(currentRow, 2).Value = "Place Type";
                worksheet.Cell(currentRow, 3).Value = "Source";
                foreach (var nametype in places)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = nametype.Name;
                    worksheet.Cell(currentRow, 2).Value = nametype.PlaceType;
                    worksheet.Cell(currentRow, 3).Value = nametype.Source;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "List_place_type.xlsx");
                }

            }
        }
    }
}
