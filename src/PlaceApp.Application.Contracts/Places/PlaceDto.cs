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
        public string Name {
            get { return name; }
            set { name = value.Trim(); }
        } 
        public string Source { get; set; }
        public string Status { 
            get { return status.ToString(); } 
            set { status = (StatusType)Enum.Parse(typeof(StatusType), value); } }
        public string PlaceType { get; set; } 
        

    }
    public class PlaceRequestDto
    {
        public string Name { get; set; }
        public string PlaceType { get; set; }
    }
    public class PlaceReponseDto
    {
        public string Name { get; set; }
        public string Source { get; set; } 
        public StatusType Status { get; set; }  = StatusType.Pending;
        public string PlaceType { get; set; }
    }
}
