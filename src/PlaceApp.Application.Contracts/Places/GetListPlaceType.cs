using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace PlaceApp.Places
{
    public class GetListPlaceType : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
   
}
