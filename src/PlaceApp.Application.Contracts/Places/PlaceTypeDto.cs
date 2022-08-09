using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace PlaceApp.Places
{
    public class PlaceTypeDto : EntityDto<Guid>
    {
        private string typeName;
        private string type;
        public string Type {
            get { return type; }
            set { type = value.Trim(); }
        }
        public string TypeName
        {
            get { return typeName; }
            set { typeName = value.Trim(); }
        }
    }
    public class PlaceTypeRequestDto
    {
        public string Type { get; set; }
        public string TypeName { get; set; }
    }
    public class PlaceTypeReponseDto 
    {
        public string Type { get; set; }
        public string TypeName { get; set; }
    }

}
