using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace PlaceApp.Places
{
    public class PlaceDto : EntityDto<Guid>
    {
        private string name;
        private StatusType status;
        private string placeType;
        public string Name {
            get { return name; }
            set { name = value.Trim(); }
        } 
        public string Source { get; set; }
        public string Status { 
            get { return status.ToString(); } 
            set { status = (StatusType)Enum.Parse(typeof(StatusType), value); } }
        public string PlaceType { 
            get { return placeType; } 
            set { placeType = value.Trim(); }
        } 
        

    }
    public class PlaceRequestDto
    {
        public string Name { get; set; }
        public string PlaceType { get; set; }
    }
}
